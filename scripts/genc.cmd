@ECHO OFF
SETLOCAL ENABLEDELAYEDEXPANSION

SET "input=%1"
IF "%input%"=="" (
    ECHO Please provide a valid contest number.
    EXIT /B 1
)

:: Determine contest type and number
IF "%input:~0,1%"=="b" (
    SET "contest_type=biweekly"
    SET "contest_number=%input:~1%"
) ELSE (
    SET "contest_type=weekly"
    SET "contest_number=%input%"
)

:: Capitalize first letter of contest type
IF "%contest_type%"=="biweekly" (
    SET "capitalized_type=Biweekly"
) ELSE (
    SET "capitalized_type=Weekly"
)

SET "target_dir=contests\%contest_type%\%contest_number%"

IF EXIST "%target_dir%" (
    ECHO Existing contest folder.
    EXIT /B 1
)

:: Create directory and files
MD "%target_dir%"
TYPE NUL > "%target_dir%\Q1.cs"
TYPE NUL > "%target_dir%\Q2.cs"
TYPE NUL > "%target_dir%\Q3.cs"
TYPE NUL > "%target_dir%\Q4.cs"

:: Update GlobalUsing.cs
(
    ECHO global using Running = %capitalized_type%_%contest_number%_Q1;
    MORE +1 GlobalUsing.cs
) > .tmp
MOVE /Y .tmp GlobalUsing.cs > NUL

:: Create empty files
TYPE NUL > testcase.txt
TYPE NUL > answer.txt

:: Open in VSCode
CALL code "%target_dir%\Q1.cs"

ECHO Created %contest_type% contest %contest_number% in %target_dir%
ENDLOCAL