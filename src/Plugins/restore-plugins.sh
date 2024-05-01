#!/bin/bash
for csprojFile in $(find -name "*.csproj" -type f)
do
    echo "$csprojFile"
    dotnet restore "$csprojFile"
done