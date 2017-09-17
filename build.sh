#!/usr/bin/env bash
dotnet restore && dotnet build
dotnet test Code\Shared\ORMS.Shared.SharedKernel\ORMS.Shared.SharedKernel.csproj