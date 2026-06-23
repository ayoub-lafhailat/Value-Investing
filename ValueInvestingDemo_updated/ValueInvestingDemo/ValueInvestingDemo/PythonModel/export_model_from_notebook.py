"""
Run this logic after the final training cell in the notebook, where `models` and `feature_cols` already exist.
It exports only the Future Adj Close model for the .NET demo application.
"""

import json
from pathlib import Path
import joblib

output_folder = Path(__file__).resolve().parent

future_adj_close_model = models["Future Adj Close"]  # noqa: F821 - available when run inside the notebook

joblib.dump(
    future_adj_close_model,
    output_folder / "value_investing_future_adj_close_model.joblib"
)

with open(output_folder / "value_investing_feature_cols.json", "w", encoding="utf-8") as file:
    json.dump(feature_cols, file, indent=2)  # noqa: F821 - available when run inside the notebook

print("Exported Future Adj Close model and feature column list.")
