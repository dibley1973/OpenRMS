#!/usr/bin/env bash
dotnet restore
dotnet clean -c Release
dotnet build OpenRMS.sln -c Release