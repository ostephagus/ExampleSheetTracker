# Example Sheet Tracker

A program to track progress through example sheets.

## How it works

A hierarchy of terms, courses, sheets and questions are stored in an XML file that is read by the program. The user is then able to navigate through this heirarchy, and is provided with infomration about progress through example sheets.

## To do for next versions
### Next minor versions (v1.1, 1.2, 1.3)
- **Get an icon**: Currently the application does not have an icon for the taskbar. It needs to be approximately 64x64 and in ICO format.
- **Finer question progress control**: I would like to, as well as the dropdown, be able to input a percentage of progress through the question for better control.
- **Giving questions names**: For putting past paper assignments into the tracker, it is useful to be able to rename the usual Q1 to, e.g., 2022 Q3
- **Better file selection**: Currently the system uses a file named `Data.xml` that is in the same directory as the executable. It is desirable for this to be able to be chosen by the user in the case this file is not found.

### Next major version (v2.0)
- **Timer system**: to allow the user to select the question they are currently on, and then the program will time how long they are spending on each question. This is currently in development on the branch QuestionTimers.

