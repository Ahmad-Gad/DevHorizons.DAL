$jsonFile = "C:\Dev\DAL\DevHorizons.DAL\DevHorizons.DAL.WebApi\JsonFiles\MemoryThresholdWarningsList.json";
$jsonData = Get-Content -Path $jsonFile | Out-String | ConvertFrom-Json;
$groupedData = $jsonData | Group CacheKey;
$filteredByMax = $groupedData | Foreach { $_.Group | Sort CacheSize -Descending | Select -First 1 };
$totalMemoryBytes = $filteredByMax | Measure-Object -Sum -Property CacheSize | Select Sum -ExpandProperty Sum;
Write-Host "Total Memory (Bytes): $totalMemoryBytes";
Write-Host "Total Memory (KB): $([Math]::Round($totalMemoryBytes / 1kb, 2))";
Write-Host "Total Memory (MB): $([Math]::Round($totalMemoryBytes / 1mb))";
Write-Host "Total Memory (GB): $([Math]::Round($totalMemoryBytes / 1gb))";
