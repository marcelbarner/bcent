param(
# Parameter help description
    [Parameter(Position = 0)]
    [String]
    $Url = "http://localhost:5000/swagger/v1/swagger.json"
)


$currentLocation = Get-Location;

$result = Invoke-RestMethod -Uri $Url -ContentType "application/json"
$jsonResult = $result | ConvertTo-Json -Depth 100
Set-Location "$PSScriptRoot/../projects/WebApp";
New-Item -Path "./v1.json" -Value $jsonResult -Force
npx ng-openapi-gen --input ./v1.json --output ./src/app/api
Remove-Item -Path "./v1.json"

Set-Location $currentLocation