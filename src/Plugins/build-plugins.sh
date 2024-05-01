#!/bin/bash
for csprojFile in $(find -name "*.csproj" -type f)
do
    echo "$csprojFile"
    dotnet build "$csprojFile" -c Release --no-restore
done