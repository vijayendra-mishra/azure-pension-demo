# PowerShell script to test release-please branch cleanup logic

Write-Host "🧪 Testing release-please branch cleanup logic..." -ForegroundColor Green

# Get remote branches
Write-Host "🔍 Looking for release-please branches..." -ForegroundColor Blue
$remoteBranches = git ls-remote --heads origin

# Check for the specific release-please branch pattern
$releasePleaseBranch = $remoteBranches | Where-Object { $_ -match "release-please--branches--main" }

if ($releasePleaseBranch) {
    Write-Host "📋 Found release-please--branches--main branch to delete" -ForegroundColor Yellow
    Write-Host "🗑️ Would delete: release-please--branches--main" -ForegroundColor Red
    # Uncomment the next line to actually delete:
    # git push origin --delete "release-please--branches--main"
} else {
    Write-Host "ℹ️ No release-please--branches--main branch found" -ForegroundColor Gray
}

# Also check for any other release-please branches (fallback)
$allReleaseBranches = $remoteBranches | Where-Object { $_ -match "release-please" } | ForEach-Object {
    ($_ -split "`t")[1] -replace "refs/heads/", ""
}

if ($allReleaseBranches) {
    Write-Host "📋 Found additional release-please branches:" -ForegroundColor Yellow
    $allReleaseBranches | ForEach-Object {
        Write-Host "🗑️ Would delete branch: $_" -ForegroundColor Red
        # Uncomment the next line to actually delete:
        # git push origin --delete "$_"
    }
} else {
    Write-Host "ℹ️ No additional release-please branches found" -ForegroundColor Gray
}

Write-Host "✅ Cleanup test completed" -ForegroundColor Green
