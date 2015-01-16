# Unity-iOS QR Plugin

## Usage

1. Copy the **Plugins** folder to your Unity project.
2. Run the method *UnityIOSQRReader.ScanQR(Object_Name, Method_Name)*
3. In *Object_Name* object implement the *Method_Name* callBack function called when a new code is read.

The script *Main.cs* includes a running example.

## Content

**/Scripts/Main**

Demo script that fires the method to scan a QR code.

**/Plugins/IOSQRReader**

Script that fires a native intent to scan and reads the QR code.

**/Pugings/IOS**

Includes de Controller with the QR scan view. Change the xib to include your own scanner design.

