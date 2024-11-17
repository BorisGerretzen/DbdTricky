import json
import os

# File paths
input_file = "results.json"
output_dir = "output"
os.makedirs(output_dir, exist_ok=True)

# Load data from results.json
try:
    with open(input_file, "r", encoding="utf-8") as f:
        data = json.load(f)
except FileNotFoundError:
    print(f"Error: {input_file} not found.")
    exit(1)
except json.JSONDecodeError as e:
    print(f"Error: Failed to parse JSON - {e}")
    exit(1)

# Process each result
for item in data:
    for result in item.get("results", []):
        filename = result["test"]["filename"].replace(".bru", ".json")  # Change extension to .json
        response_data = result.get("response", {}).get("data", {})
        
        if response_data:
            filepath = os.path.join(output_dir, filename)
            with open(filepath, "w", encoding="utf-8") as f:
                json.dump(response_data, f, indent=4)
                print(f"Saved response to {filepath}")
