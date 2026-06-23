# Value Investing Demo

This project is a simple ASP.NET Core Razor Pages demo application for a value investing machine learning model. It follows the same MVC-like layered style as the Portfolio Watcher project:

- `Core.Domain` contains domain models, DTOs, interfaces, services and custom exceptions.
- `Core.Data` contains infrastructure code. In this app, the repository calls a Python prediction script.
- `ValueInvestingDemo` contains Razor Pages, PageModels, Bootstrap views and view models.
- `UnitTest` contains xUnit and Moq unit tests.

## Goal

The application demonstrates a trained model outside of the notebook environment. A user can enter financial values manually or load example input values. The app then predicts `Future Adj Close`.

This is educational evidence for LO5 Manage & Control:

- Transparency: the input features, target variable, pipeline and metrics are documented.
- Explainability: the app shows what the model predicts and explains the main limitations.
- Transferability: the model is used through a separate service/repository structure and can be reproduced by exporting the model from the notebook.

## Model

Final target used in the demo:

```text
Future Adj Close
```

Model type from the notebook:

```text
Linear Regression
```

Input features:

```text
Adj. Close
Volume
Market-Cap
Price to Earnings Ratio (ttm)
Price to Sales Ratio (ttm)
Price to Book Value
Price to Free Cash Flow (ttm)
EV/EBITDA
EV/Sales
Book to Market Value
Operating Income/EV
Altman Z Score
```

## Python model export

The app calls this file:

```text
ValueInvestingDemo/PythonModel/predict.py
```

The trained model file is included here:

```text
ValueInvestingDemo/PythonModel/value_investing_future_adj_close_model.joblib
```

The feature column file is included here:

```text
ValueInvestingDemo/PythonModel/value_investing_feature_cols.joblib
```

To export the model from the notebook, run the logic from:

```text
ValueInvestingDemo/PythonModel/export_model_from_notebook.py
```

inside or directly after the final notebook training cells where `models` and `feature_cols` exist.

The most important notebook code is:

```python
import json
import joblib

future_adj_close_model = models["Future Adj Close"]

joblib.dump(
    future_adj_close_model,
    "ValueInvestingDemo/PythonModel/value_investing_future_adj_close_model.joblib"
)

with open("ValueInvestingDemo/PythonModel/value_investing_feature_cols.joblib", "w", encoding="utf-8") as file:
    json.dump(feature_cols, file, indent=2)
```

## Included model files

This updated version includes the uploaded trained model and feature column files:

```text
value_investing_future_adj_close_model.joblib
value_investing_feature_cols.joblib
```

The fallback behavior is still kept in the code for transparency. If the model file is removed or not found, the Python script returns a naive fallback prediction equal to the current `Adj. Close`, and the UI clearly marks this as a fallback.

## Requirements

.NET:

```text
.NET 8 SDK
```

Python:

```text
Python 3.10+
pandas
scikit-learn
joblib
```

Install Python requirements:

```bash
cd ValueInvestingDemo/PythonModel
pip install -r requirements.txt
```

If your Python executable is not called `python`, set this environment variable before running the app:

```bash
PYTHON_EXECUTABLE=python3
```

## Run the app

From the solution folder:

```bash
dotnet restore
dotnet run --project ValueInvestingDemo
```

Then open the local URL shown in the terminal.

## Run tests

```bash
dotnet test
```

## Important limitation

The notebook showed that the high R² for `Future Adj Close` is largely explained by current `Adj. Close`. A naive baseline performs almost as well as the Linear Regression model. Therefore, the app should be interpreted as a deployment and explainability prototype, not as a reliable financial advice system.
