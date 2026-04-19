#!/usr/bin/env bash
set -euo pipefail

echo "==> Restoring dotnet local tools (fantomas, fsdocs)"
dotnet tool restore

echo "==> Warming up NuGet restore for the main solution"
dotnet restore Plotly.NET.sln || true

echo "==> Installing agent CLIs globally (Claude Code + Codex)"
npm install -g \
    @anthropic-ai/claude-code \
    @openai/codex \
    opencode-ai@latest 

echo "==> Aliasing agent CLIs to skip approvals (sandbox is the devcontainer itself)"
cat >> ~/.bashrc <<'EOF'

# devcontainer: agent CLIs skip approvals since the container IS the sandbox
alias claude='claude --dangerously-skip-permissions'
alias codex='codex --dangerously-bypass-approvals-and-sandbox'
EOF

chmod +x build.sh

echo "==> Done. Verify with:"
echo "     ./build.sh                # default build target"
echo "     ./build.sh RunTestsAllFast"
echo "     claude --version"
echo "     codex --version"
