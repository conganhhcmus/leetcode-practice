#!/bin/bash
if [ $1 = "" ]; then
    echo "Please provide a valid problem name."
    exit 1
elif [ -d "problems/$1" ]; then
    echo "Existing problem folder."
    exit 1
else
    mkdir -p "problems/$1"
    touch "problems/$1/Solution.cs"

    code "problems/$1/Solution.cs"
fi
