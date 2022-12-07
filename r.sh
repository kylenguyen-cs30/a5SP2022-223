# Name : Hoang Nguyen
# Email : Hnguyen1193@csu.fullerton.edu
# Course : CPSC 223N
# Assignment : 5

echo First remove old binary files
rm *.dll
rm *.exe


echo Compile CollideBallLogic.cs to create the file: logic.dll
mcs -target:library CollideBallLogic.cs -r:System.Drawing.dll -out:logic.dll

echo Compile CollideBallFrame.cs to create the file: UI.dll
mcs -target:library -r:System.Windows.Forms.dll -r:System.Drawing.dll -r:logic.dll -out:UI.dll CollideBallFrame.cs

echo Compile CollideBall.cs and link the previously create UI.dll file to create an executable file.
mcs -r:System -r:System.Windows.Forms -r:UI.dll -r:logic.dll -out:final.exe CollideBall.cs

echo View the list ofiles in the current folder
ls -l

echo Run the Assignment 5 program.
./final.exe

echo remove binary files
rm *.dll
rm *.exe

echo the script has terminated.

