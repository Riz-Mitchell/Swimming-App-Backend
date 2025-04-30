import pandas as pd
import json
import sys

import re

def convert_time_to_seconds(value):
    """
    Converts a time string or float to seconds.
    If in 'mm:ss.ss' format, converts to total seconds.
    If already in seconds (e.g. '54.80'), returns as float.
    """
    if isinstance(value, float):
        value = f"{value}"

    mmss_pattern = re.match(r'^(\d+):(\d+(?:\.\d+)?)$', value)
    
    if mmss_pattern:
        minutes = int(mmss_pattern.group(1))
        seconds = float(mmss_pattern.group(2))
        return minutes * 60 + seconds
    else:
        return float(value)


def main(input_csv, output_json):
    df = pd.read_csv(input_csv)
    
    # print(df.head())  # Debugging line to check the DataFrame content
    
    intervals = [int(col.strip('m')) for col in df.columns]
    
    # print(intervals)  # Debugging line to check the intervals

    output = []
    for _, row in df.iterrows():
        splits = []
        for i, value in enumerate(row):
            clean_time = convert_time_to_seconds(value)
            splits.append({
                "intervalInMeters": intervals[i],
                "intervalTime": clean_time
            })
        total_time = splits[-1]["intervalTime"]
        output.append({
            "totalTime": total_time,
            "splits": splits
        })

    with open(output_json, 'w') as f:
        json.dump(output, f, indent=4)

if __name__ == "__main__":
    if len(sys.argv) != 3:
        print("Usage: python convert_csv_to_json.py input.csv output.json")
        sys.exit(1)
    
    input_csv = sys.argv[1]
    output_json = sys.argv[2]
    main(input_csv, output_json)
