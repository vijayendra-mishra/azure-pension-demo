#!/bin/bash

echo "🧪 Testing release-please branch cleanup logic..."

# Simulate the cleanup logic from our CI/CD pipeline
echo "🔍 Looking for release-please branches..."
git ls-remote --heads origin > remote_branches.txt

# Check for the specific release-please branch pattern
if grep -q "release-please--branches--main" remote_branches.txt; then
  echo "📋 Found release-please--branches--main branch to delete"
  echo "🗑️ Would delete: release-please--branches--main"
  # Uncomment the next line to actually delete:
  # git push origin --delete "release-please--branches--main"
else
  echo "ℹ️ No release-please--branches--main branch found"
fi

# Also check for any other release-please branches (fallback)
RELEASE_BRANCHES=$(grep "release-please" remote_branches.txt | cut -d$'\t' -f2 | sed 's|refs/heads/||' || true)

if [ ! -z "$RELEASE_BRANCHES" ]; then
  echo "📋 Found additional release-please branches:"
  echo "$RELEASE_BRANCHES"
  
  for branch in $RELEASE_BRANCHES; do
    echo "🗑️ Would delete branch: $branch"
    # Uncomment the next line to actually delete:
    # git push origin --delete "$branch"
  done
else
  echo "ℹ️ No additional release-please branches found"
fi

rm -f remote_branches.txt
echo "✅ Cleanup test completed"
