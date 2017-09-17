#!/usr/bin/env bash
dotnet restore
dotnet clean -c Release
dotnet build Code/Shared/ORMS.Shared.SharedKernel/
dotnet build Code/Shared/ORMS.Shared.SharedKernel.UnitTests/