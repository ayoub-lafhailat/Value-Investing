# Value Investing AI - Machine Learning for Fundamental Stock Analysis

## Overview

This project explores the use of Machine Learning and financial data analysis to identify potentially undervalued and overvalued stocks using value investing principles.

The goal of the project is to combine traditional value investing metrics with data science techniques to analyze large financial datasets and experiment with predictive models for stock evaluation and price forecasting.

The project was developed as part of the AI, Data & Machine Learning specialization at Fontys University of Applied Sciences, following the AMD Project Methodology. 

---

## Project Goals

The project focuses on two main research directions:

* Predicting future stock prices using financial indicators
* Identifying undervalued versus overvalued companies based on company fundamentals

The project investigates whether Machine Learning models can discover relationships between financial ratios and future stock performance while remaining aligned with value investing principles.

---

## Research Question

> Can Machine Learning models use company fundamentals and financial ratios to identify potentially undervalued stocks or predict future stock price movements?

---

## Technologies Used

### Programming Languages

* Python

### Libraries

* pandas
* numpy
* scikit-learn
* matplotlib
* seaborn
* shap

### Tools

* Jupyter Notebook
* VS Code
* GitHub

---

## Dataset

The project uses large-scale historical stock and financial datasets containing:

* Adjusted stock prices
* Market capitalization
* Valuation ratios
* Financial statement metrics
* Volume data
* Balance sheet indicators

### Examples of Features

* P/E Ratio (TTM)
* Price to Book
* EV/EBITDA
* Price to Sales
* Operating Income / EV
* Book-to-Market Value
* Altman Z-Score
* Dividend Yield
* Volume
* Market Cap

### Target Variables

Depending on the experiment:

* Future Adjusted Close price
* Undervalued / Overvalued classification

---

## Machine Learning Pipeline

The project follows an iterative AI development methodology including:

1. Domain Understanding
2. Data Collection
3. Data Cleaning
4. Exploratory Data Analysis (EDA)
5. Feature Engineering
6. Model Training
7. Model Evaluation
8. Iteration & Improvement

This workflow is based on the AMD Project Methodology used during the semester. 

---

## Data Preparation

Several preprocessing and data engineering steps were applied:

* Missing value handling
* Outlier detection
* Feature selection
* Correlation analysis
* Log transformations
* Date filtering
* Scaling & normalization

Special attention was given to:

* Preventing data leakage
* Aligning financial data with future price targets
* Removing unrealistic financial ratio outliers

---

## Exploratory Data Analysis

The project includes:

* Correlation heatmaps
* Distribution analysis
* Financial ratio exploration
* Feature importance analysis
* Trend analysis over time

The goal of the EDA phase was to determine which financial metrics act as strong indicators for valuation or future price movement.

---

## Models Experimented With

Several Machine Learning approaches were explored, including:

### Regression Models

* Linear Regression
* Random Forest Regressor
* Gradient Boosting
* XGBoost (optional)

### Classification Models

* Logistic Regression
* Random Forest Classifier
* Support Vector Machine

### Evaluation Metrics

Regression:

* MAE
* RMSE
* R² Score

Classification:

* Accuracy
* Precision
* Recall
* F1 Score

---

## Project Structure

```text
project-root/
│
├── data/
│   ├── raw/
│   ├── processed/
│
├── notebooks/
│   ├── EDA.ipynb
│   ├── preprocessing.ipynb
│   ├── modelling.ipynb
│
├── models/
│   ├── trained_models/
├── docs/
│   ├── research/
│
├── requirements.txt
├── README.md
```

The research document consist of: Domain Analysis, Data dictionary, Proposal, Data requirements and a Ethical check. Based on a expert interview with a relevant stakeholder.
---

## Key Challenges

Some important challenges addressed during the project:

* Financial data quality issues
* Extreme outliers in valuation ratios
* Large dataset handling
* Feature correlation vs causation
* Preventing overfitting
* Time-series alignment and leakage prevention
* Model explainability

---

## Results

The project demonstrated that:

* Certain financial ratios show meaningful relationships with stock valuation
* Data quality and preprocessing heavily influence model performance
* Simpler models can sometimes outperform more complex approaches
* Financial prediction remains highly challenging due to market uncertainty

The project focuses primarily on experimentation, research, and methodology rather than production-grade trading systems.

---

## Future Improvements

Possible future improvements include:

* Incorporating macroeconomic indicators
* Using quarterly filing lag adjustments
* Deep Learning experiments
* Time-series forecasting models
* Sentiment analysis from financial news
* Portfolio optimization
* Real-time inference dashboard

---

## My Contribution

This project was fully focused on:

* Data engineering
* Financial data analysis
* Machine Learning experimentation
* Feature selection
* Model validation
* Exploratory Data Analysis
* Research into value investing methodologies
* Building reproducible ML workflows

A major focus was placed on understanding the relationship between traditional value investing metrics and modern AI techniques.

---

## Disclaimer

This is an ongoing project and is for educational and research purposes only.

It does not provide financial advice or investment recommendations.

---
* AMD Project Methodology 
* Fontys HBO-ICT AI, Data & Machine Learning Semester Materials 
