import pandas as pd
import json
import sys
import re
from pathlib import Path

def convert_time_to_seconds(value):
    if isinstance(value, float):
        value = f"{value}"
    mmss_pattern = re.match(r'^(\d+):(\d+(?:\.\d+)?)$', value)
    if mmss_pattern:
        minutes = int(mmss_pattern.group(1))
        seconds = float(mmss_pattern.group(2))
        return minutes * 60 + seconds
    else:
        return float(value)

def process_file(input_csv, output_json):
    df = pd.read_csv(input_csv)
    intervals = [int(col.strip('m')) for col in df.columns]

    output = []
    for _, row in df.iterrows():
        splits_dict = {}
        for i, value in enumerate(row):
            clean_time = convert_time_to_seconds(value)
            splits_dict[intervals[i]] = round(clean_time, 2)

        total_time = splits_dict[max(splits_dict.keys())]
        output.append({
            "TotalTime": total_time,
            "SplitsByDistance": splits_dict
        })

    with open(output_json, 'w') as f:
        json.dump(output, f, indent=4)

def main(input_folder):
    input_folder = Path(input_folder)
    output_folder = input_folder.parent / "Timesheets-In-JSON"
    output_folder.mkdir(exist_ok=True)

    for csv_file in input_folder.glob("*.csv"):
        output_json = output_folder / (csv_file.stem + ".json")
        try:
            process_file(csv_file, output_json)
            print(f"Converted {csv_file.name} → {output_json.name}")
        except Exception as e:
            print(f"Error processing {csv_file.name}: {e}")

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Usage: python convert.py input_folder/")
        sys.exit(1)

    main(sys.argv[1])
