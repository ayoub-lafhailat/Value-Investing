"""
Optional standalone training script.
Use this if you export the completed modelling dataset from the notebook to CSV.
Expected CSV: model_df_complete.csv with the same feature columns and Future Adj Close target.
"""

import json
from pathlib import Path
import joblib
import pandas as pd
from sklearn.linear_model import LinearRegression
from sklearn.model_selection import train_test_split

BASE_PATH = Path(__file__).resolve().parent
DATA_FILE = BASE_PATH / "model_df_complete.csv"
MODEL_FILE = BASE_PATH / "value_investing_future_adj_close_model.joblib"
FEATURE_COLUMNS_FILE = BASE_PATH / "value_investing_feature_cols.json"

feature_cols = [
    "Adj. Close",
    "Volume",
    "Market-Cap",
    "Price to Earnings Ratio (ttm)",
    "Price to Sales Ratio (ttm)",
    "Price to Book Value",
    "Price to Free Cash Flow (ttm)",
    "EV/EBITDA",
    "EV/Sales",
    "Book to Market Value",
    "Operating Income/EV",
    "Altman Z Score",
]

target_col = "Future Adj Close"

if not DATA_FILE.exists():
    raise FileNotFoundError(
        "model_df_complete.csv was not found. Export model_df_complete from the notebook first."
    )

model_df_complete = pd.read_csv(DATA_FILE)
model_df_complete = model_df_complete.dropna(subset=feature_cols + [target_col])

X = model_df_complete[feature_cols]
y = model_df_complete[target_col]

X_train, X_validation, y_train, y_validation = train_test_split(
    X,
    y,
    test_size=0.2,
    random_state=42
)

model = LinearRegression()
model.fit(X_train, y_train)

joblib.dump(model, MODEL_FILE)

with open(FEATURE_COLUMNS_FILE, "w", encoding="utf-8") as file:
    json.dump(feature_cols, file, indent=2)

print(f"Saved model to {MODEL_FILE}")
print(f"Saved feature columns to {FEATURE_COLUMNS_FILE}")
