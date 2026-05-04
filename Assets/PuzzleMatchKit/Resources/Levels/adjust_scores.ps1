$levelsPath = "C:\Users\joaop\Desktop\Uni\Estagio\TripleMatch\Assets\PuzzleMatchKit\Resources\Levels"
$original = @{}
$newScores = @{}

for ($level = 1; $level -le 100; $level++) {
    $filePath = Join-Path $levelsPath "$level.json"
    
    # Determine multiplier based on level range
    $multiplier = if ($level -le 20) { 0.60 }
                  elseif ($level -le 40) { 0.62 }
                  elseif ($level -le 60) { 0.64 }
                  elseif ($level -le 80) { 0.66 }
                  else { 0.68 }
    
    # Read JSON file
    $content = Get-Content $filePath -Raw
    $json = $content | ConvertFrom-Json
    
    # Store original values for verification
    if ($level -eq 1 -or $level -eq 20 -or $level -eq 50 -or $level -eq 100) {
        $original[$level] = @{
            score1 = $json.score1
            score2 = $json.score2
            score3 = $json.score3
        }
    }
    
    # Apply multiplier and round to whole numbers
    $json.score1 = [math]::Round($json.score1 * $multiplier)
    $json.score2 = [math]::Round($json.score2 * $multiplier)
    $json.score3 = [math]::Round($json.score3 * $multiplier)
    
    # Store new values for verification
    if ($level -eq 1 -or $level -eq 20 -or $level -eq 50 -or $level -eq 100) {
        $newScores[$level] = @{
            score1 = $json.score1
            score2 = $json.score2
            score3 = $json.score3
        }
    }
    
    # Write updated JSON back to file
    $json | ConvertTo-Json | Set-Content $filePath
}

# Report results
Write-Host ""
Write-Host "=== SCORE ADJUSTMENTS COMPLETE ===" -ForegroundColor Green
Write-Host ""

Write-Host "Level 1 (60% of original):" -ForegroundColor Cyan
Write-Host "  Original: score1=$($original[1].score1), score2=$($original[1].score2), score3=$($original[1].score3)"
Write-Host "  New:      score1=$($newScores[1].score1), score2=$($newScores[1].score2), score3=$($newScores[1].score3)"
Write-Host ""

Write-Host "Level 20 (60% of original):" -ForegroundColor Cyan
Write-Host "  Original: score1=$($original[20].score1), score2=$($original[20].score2), score3=$($original[20].score3)"
Write-Host "  New:      score1=$($newScores[20].score1), score2=$($newScores[20].score2), score3=$($newScores[20].score3)"
Write-Host ""

Write-Host "Level 50 (64% of original):" -ForegroundColor Cyan
Write-Host "  Original: score1=$($original[50].score1), score2=$($original[50].score2), score3=$($original[50].score3)"
Write-Host "  New:      score1=$($newScores[50].score1), score2=$($newScores[50].score2), score3=$($newScores[50].score3)"
Write-Host ""

Write-Host "Level 100 (68% of original):" -ForegroundColor Cyan
Write-Host "  Original: score1=$($original[100].score1), score2=$($original[100].score2), score3=$($original[100].score3)"
Write-Host "  New:      score1=$($newScores[100].score1), score2=$($newScores[100].score2), score3=$($newScores[100].score3)"
Write-Host ""
