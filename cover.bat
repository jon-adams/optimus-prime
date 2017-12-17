@echo off
REM Runs code coverage on the pre-built Debug build of the test library
REM
REM Note: Requires the project to be built in Visual Studio first (since didn't want to setup a whole psake or similar console build system just yet)
"opencover/OpenCover.Console.exe" -register:user -target:"nunit/nunit3-console.exe" "-targetargs:\"optimus prime.Tests\bin\Debug\Optimus.Prime.Tests.dll\" --result:Optimus.Prime.Tests.dll.xml;format=nunit3 --framework=net-4.5" -output:"coverage.xml"
echo on