#!/bin/bash
dir="$(cd $(dirname ${BASH_SOURCE[0]}) && pwd)"
cd $dir/../
pwd
echo "Building ECDefine.Game"
output="$(msbuild /property:Configuration=Debug /p:WarningLevel=0 /verbosity:minimal ./Src/Tools.ECS.ECDefine.Game/Tools.ECS.ECDefine.Game.csproj)"
echo $output

echo "Copy files"
rm -rf ./Src/Tools.ECS.CodeGenEntitas/Src/Common
cp -rf ./Src/Tools.ECS.ECDefine.Game/Src/Common ./Src/Tools.ECS.CodeGenEntitas/Src/Common
