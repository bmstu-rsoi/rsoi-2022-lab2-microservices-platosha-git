#!/usr/bin/env bash
sudo chmod +x ./scripts/wait-for.sh

IFS="," read -ra PORTS <<<"$WAIT_PORTS"

PIDs=()
for port in "${PORTS[@]}"; do
  "$path"/scripts/wait-for.sh -t 120 "http://localhost:$port" -- echo "Host localhost:$port is active" &
  PIDs+=($!)
done

for pid in "${PIDs[@]}"; do
  if ! wait "${pid}"; then
    exit 1
  fi
done
