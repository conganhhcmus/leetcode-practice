#!/bin/bash
if [ $1 = "" ]; then
    echo "Please provide a valid contest name."
    exit 1
elif [ -d "contests/$1" ]; then
    echo "Existing contest folder."
    exit 1
else
    mkdir -p "contests/$1"
    touch "contests/$1/Q1.cs"
    touch "contests/$1/Q2.cs"
    touch "contests/$1/Q3.cs"
    touch "contests/$1/Q4.cs"

    code "contests/$1/Q1.cs"
    sed -i "" "1 s/.*/global using Running = Contests_${1}_Q1;/g" GlobalUsing.cs
fi
