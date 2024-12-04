@ECHO OFF
SET contest_name=%1
IF "%contest_name%" == "" GOTO missing_contest_name
IF EXIST "contests/%contest_name%/" GOTO existing_contest_folder

IF NOT EXIST "contests/%contest_name%/" MKDIR "contests/%contest_name%/"
TYPE NUL > ./contests/%contest_name%/Q1.cs
TYPE NUL > ./contests/%contest_name%/Q2.cs
TYPE NUL > ./contests/%contest_name%/Q3.cs
TYPE NUL > ./contests/%contest_name%/Q4.cs

CALL code "./contests/%contest_name%/Q1.cs"
CALL ECHO global using Running = Contests_%contest_name%_Q1;> .tmp
FOR /f "skip=1 delims=" %%l IN (GlobalUsing.cs) DO ECHO %%l>> .tmp
CALL TYPE .tmp > GlobalUsing.cs
CALL DEL .tmp
ECHO Done!
GOTO end

:missing_contest_name
ECHO Please provide a valid contest name.
GOTO end

:existing_contest_folder
ECHO Existing contest folder.

:end