import base64
import json
import sys
from pathlib import Path

FEATURE_MAP = {
    "AdjClose": "Adj. Close",
    "Volume": "Volume",
    "MarketCap": "Market-Cap",
    "PriceToEarningsRatioTtm": "Price to Earnings Ratio (ttm)",
    "PriceToSalesRatioTtm": "Price to Sales Ratio (ttm)",
    "PriceToBookValue": "Price to Book Value",
    "PriceToFreeCashFlowTtm": "Price to Free Cash Flow (ttm)",
    "EvEbitda": "EV/EBITDA",
    "EvSales": "EV/Sales",
    "BookToMarketValue": "Book to Market Value",
    "OperatingIncomeEv": "Operating Income/EV",
    "AltmanZScore": "Altman Z Score",
}

DEFAULT_FEATURE_COLUMNS = list(FEATURE_MAP.values())
MODEL_FILE = "value_investing_future_adj_close_model.joblib"
FEATURE_COLUMNS_JOBLIB_FILE = "value_investing_feature_cols.joblib"
FEATURE_COLUMNS_JSON_FILE = "value_investing_feature_cols.json"


def read_input() -> dict:
    if len(sys.argv) < 2:
        raise ValueError("No input argument was provided to predict.py.")

    encoded_input = sys.argv[1]
    decoded_input = base64.b64decode(encoded_input).decode("utf-8")
    return json.loads(decoded_input)


def make_feature_row(input_data: dict) -> dict:
    row = {}

    for dto_name, feature_name in FEATURE_MAP.items():
        if dto_name not in input_data:
            raise ValueError(f"Missing input field: {dto_name}")

        row[feature_name] = float(input_data[dto_name])

    return row


def predict_with_model(feature_row: dict, base_path: Path) -> dict:
    try:
        import pandas as pd
        import joblib
    except ImportError as exc:
        raise RuntimeError(
            "Required Python packages are missing. Install them with: pip install -r PythonModel/requirements.txt"
        ) from exc

    model_path = base_path / MODEL_FILE
    feature_columns_joblib_path = base_path / FEATURE_COLUMNS_JOBLIB_FILE
    feature_columns_json_path = base_path / FEATURE_COLUMNS_JSON_FILE

    if not model_path.exists():
        return {
            "predictedFutureAdjClose": feature_row["Adj. Close"],
            "isFallbackPrediction": True,
            "warning": "No trained joblib model was found. The app returned a naive baseline prediction equal to the current Adjusted Close. Export the trained model from the notebook to use the real model."
        }

    model = joblib.load(model_path)

    feature_columns = DEFAULT_FEATURE_COLUMNS
    if feature_columns_joblib_path.exists():
        feature_columns = joblib.load(feature_columns_joblib_path)
    elif feature_columns_json_path.exists():
        feature_columns = json.loads(feature_columns_json_path.read_text(encoding="utf-8"))

    missing_columns = [column for column in feature_columns if column not in feature_row]
    if missing_columns:
        raise ValueError(f"The model expects feature columns that are not available in the web input: {missing_columns}")

    dataframe = pd.DataFrame([[feature_row[column] for column in feature_columns]], columns=feature_columns)
    prediction = model.predict(dataframe)[0]

    return {
        "predictedFutureAdjClose": float(prediction),
        "isFallbackPrediction": False,
        "warning": None
    }


def main() -> None:
    input_data = read_input()
    feature_row = make_feature_row(input_data)
    base_path = Path(__file__).resolve().parent
    result = predict_with_model(feature_row, base_path)
    print(json.dumps(result))


if __name__ == "__main__":
    try:
        main()
    except Exception as exc:
        print(str(exc), file=sys.stderr)
        sys.exit(1)
