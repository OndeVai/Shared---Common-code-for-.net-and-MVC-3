@echo off
set nantfile=Ninject.build
set nantexe=tools\nant\nant.exe
set buildlog=Ninject.Extensions.NamedScope-Nant-Build.log
set unittestlog=Ninject.Extensions.NamedScope-Nant-unit-tests.log

%nantexe% -buildfile:%nantfile% clean %1 %2 %3 %4 %5 %6 %7 %8
IF ERRORLEVEL 1 GOTO Failed
%nantexe% -buildfile:%nantfile% package-source %1 %2 %3 %4 %5 %6 %7 %8
IF ERRORLEVEL 1 GOTO Failed
%nantexe% -buildfile:%nantfile% "-D:build.config=release" allPlatforms %1 %2 %3 %4 %5 %6 %7 %8
IF ERRORLEVEL 1 GOTO Failed
%nantexe% -buildfile:%nantfile% -q -nologo revert

IF ERRORLEVEL 1 GOTO Failed

echo "Release build completed."
GOTO End

:Failed
%nantexe% -buildfile:%nantfile% -q -nologo revert
echo "============================================================"
echo "BUILD FAILED"
echo "============================================================"

:End
if %NoPause%=="true" goto ENDBATCHFILE 
pause
:ENDBATCHFILE