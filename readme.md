# Example Sheet Tracker

A program to track progress through example sheets.

## How it works

A hierarchy of terms, courses, sheets and questions are stored in an XML file that is read by the program. The user is then able to navigate through this heirarchy, and is provided with infomration about progress through example sheets.

## To do for next versions
### Next minor version (v1.0.1)
- **Updates to progress display for courses**: Currently, if there is no active sheet an "on schedule" is displayed. It would be nice if this could just be blank.
- **Finer question progress control**: I would like to, as well as the dropdown, be able to input a percentage of progress through the question for better control.

## Next major version (v1.1)

- **Get an icon**: Currently the application does not have an icon for the taskbar. It needs to be approximately 64x64 and in ICO format.
- **Better file selection**: Currently the system uses a file named `Data.xml` that is in the same directory as the executable. It is desirable for this to be able to be chosen by the user in the case this file is not found.

## Next complete revision (v2.0)
- **Timer system**: to allow the user to select the question they are currently on, and then the program will time how long they are spending on each question.
