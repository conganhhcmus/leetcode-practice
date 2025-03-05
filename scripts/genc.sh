#!/bin/bash
if [ -z "$1" ]; then
    echo "Please provide a valid contest number."
    exit 1
fi

# Determine contest type and number
if [[ $1 == b* ]]; then
    contest_type="biweekly"
    contest_number="${1:1}"
else
    contest_type="weekly"
    contest_number="$1"
fi
# Capitalize first letter of contest type
capitalized_type=$(echo "${contest_type:0:1}" | tr '[:lower:]' '[:upper:]')"${contest_type:1}"

target_dir="contests/${contest_type}/${contest_number}"

if [ -d "$target_dir" ]; then
    echo "Existing contest folder."
    exit 1
else
    mkdir -p "$target_dir"
    touch "$target_dir/Q1.cs"
    touch "$target_dir/Q2.cs"
    touch "$target_dir/Q3.cs"
    touch "$target_dir/Q4.cs"

    code "$target_dir/Q1.cs"
    sed -i "" "1 s/.*/global using Running = ${capitalized_type}_${contest_number}_Q1;/g" GlobalUsing.cs
    > testcase.txt
    > answer.txt
fi