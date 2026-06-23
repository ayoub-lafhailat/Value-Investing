using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Core.Domain.Dto;
using Core.Domain.Exceptions;
using Core.Domain.Interfaces;

namespace Core.Data.Repository
{
    public class PythonPredictionRepo : IPredictionRepository
    {
        private const string PythonExecutableEnvironmentVariable = "PYTHON_EXECUTABLE";

        public StockPredictionResultDTO PredictFutureAdjClose(StockPredictionInputDTO input)
        {
            try
            {
                string pythonExecutable = Environment.GetEnvironmentVariable(PythonExecutableEnvironmentVariable) ?? "python";
                string scriptPath = GetPredictionScriptPath();
                string inputJson = JsonSerializer.Serialize(input);
                string encodedInput = Convert.ToBase64String(Encoding.UTF8.GetBytes(inputJson));

                var startInfo = new ProcessStartInfo
                {
                    FileName = pythonExecutable,
                    Arguments = $"\"{scriptPath}\" \"{encodedInput}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);

                if (process == null)
                    throw new PredictionRepositoryException("The Python prediction process could not be started.");

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                if (process.ExitCode != 0)
                    throw new PredictionRepositoryException($"Python prediction failed: {error}");

                var result = JsonSerializer.Deserialize<StockPredictionResultDTO>(
                    output,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (result == null)
                    throw new PredictionRepositoryException("Python prediction returned an empty result.");

                return result;
            }
            catch (PredictionRepositoryException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new PredictionRepositoryException("Unexpected error while calling the Python model.", exception);
            }
        }

        private static string GetPredictionScriptPath()
        {
            string baseDirectory = AppContext.BaseDirectory;
            string scriptPath = Path.Combine(baseDirectory, "PythonModel", "predict.py");

            if (File.Exists(scriptPath))
                return scriptPath;

            string developmentPath = Path.Combine(Directory.GetCurrentDirectory(), "PythonModel", "predict.py");

            if (File.Exists(developmentPath))
                return developmentPath;

            throw new PredictionRepositoryException("predict.py could not be found in the PythonModel folder.");
        }
    }
}
