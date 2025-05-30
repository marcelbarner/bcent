param(
# Parameter help description
    [Parameter(Mandatory, Position = 0)]
    [String]
    [Alias("Name")]
    $MigrationName
)

$currentLocation = Get-Location;

Set-Location "$PSScriptRoot/../";

dotnet ef migrations add $MigrationName --project .\projects\Packages\Infrastructure.SqlMigrations\Infrastructure.SqlMigrations.csproj

Set-Location $currentLocation;