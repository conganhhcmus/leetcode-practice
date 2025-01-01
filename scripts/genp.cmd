@ECHO OFF
SET problem_name=%1
IF "%problem_name%" == "" GOTO missing_problem_name
IF EXIST "problems/%problem_name%/" GOTO existing_contest_folder

@REM Problem
IF NOT EXIST "problems/%problem_name%/" MKDIR "problems/%problem_name%/"
TYPE NUL > ./problems/%problem_name%/Solution.cs
CALL code "./problems/%problem_name%/Solution.cs"

CALL ECHO global using Running = Problems_%problem_name%;> .tmp
FOR /f "skip=1 delims=" %%l IN (GlobalUsing.cs) DO ECHO %%l>> .tmp
CALL TYPE .tmp > GlobalUsing.cs
CALL DEL .tmp
CALL TYPE nul > testcase.txt
CALL TYPE nul > answer.txt
ECHO Done!
GOTO end

:missing_problem_name
ECHO Please provide a valid problem name.
GOTO end

:existing_contest_folder
ECHO Existing problem folder.

:end