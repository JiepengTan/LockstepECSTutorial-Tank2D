#!/bin/bash
dir="$(cd $(dirname ${BASH_SOURCE[0]}) && pwd)"
cd $dir/../
pwd
echo "Roslyn building CodeGenEntitas"
msbuild /property:Configuration=Debug /p:WarningLevel=3 /verbosity:minimal ./Src/Tools.ECS.CodeGenEntitas/Tools.ECS.CodeGenEntitas.csproj
