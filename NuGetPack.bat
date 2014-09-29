@echo off
set /p version="Version: "
msbuild FakeItEasy.Auto.sln /P:Configuration=Release
rmdir /S /Q nuget-pack\lib
xcopy FakeItEasy.Auto\bin\Release\FakeItEasy.Auto.dll nuget-pack\lib\4.5\ /Y
.nuget\nuget pack nuget-pack\FakeItEasy.Auto.nuspec -Version %version%
pause