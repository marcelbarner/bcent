$currentLocation = Get-Location;

Set-Location "$PSScriptRoot/../";

dotnet ef migrations remove --project .\projects\Packages\Infrastructure.SqlMigrations\Infrastructure.SqlMigrations.csproj -f

Set-Location $currentLocation;