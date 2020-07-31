# PayrollGUI

C# application that contains Payroll DLL and WPF Application that reads from Department files in JSON format.
Deparment files contain worker information (Name, ID, Payrate) and shift information (Hours worked, Date, ID).

This project contains TWO components:
1. Payroll DLL - Holds class definitions for Department, Worker, and Shift. Contains sample department JSON file to be read from.
Also contains PayrollTesting.cs, a class that has unit testing code for earlier versions of Payroll class.

2. Payroll GUI - Presents a graphical user interface created in WPF that lets the user choose a department file, populates
data into textboxes and listview. Also lets the user type in a worker ID and find their worker and shift data. 
![Screenshot (16)](https://user-images.githubusercontent.com/50625576/89061717-2e315800-d333-11ea-8f97-ee5468dccb9c.png)

![Screenshot (24)](https://user-images.githubusercontent.com/50625576/89066165-fc23f400-d33a-11ea-8a0a-0f82f4d76c29.png)

![Screenshot (22)](https://user-images.githubusercontent.com/50625576/89065911-86b82380-d33a-11ea-9434-7edd4ce1a818.png)

![Screenshot (23)](https://user-images.githubusercontent.com/50625576/89065979-a5b6b580-d33a-11ea-85e1-67477a923cdf.png)
