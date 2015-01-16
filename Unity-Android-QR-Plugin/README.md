# Unity-Android QR Plugin

## Usage

1. Copy the **Plugins** folder into your Unity project.
2. To launch the QR reader run *UnityAndroidQRReader.ScanQR(Object_Name, Method_Name)*
3. In *Object_Name* object implement the *Method_Name* callBack function called when a new code is read.

The script *Main.cs* includes a running example.

## Content

**/Scripts/Main**

Demo script that fires the method to scan a QR code.

**/Plugins/AndroidQRReader**

Script that fires a native intent to scan the QR code using the ZXing app and reads the result.

**/Pugings/Android**

It includes a .jar file generated using the eclipse project included in the *EclipseProject* folder and the manifest file. The absolute path of the main package in the eclipse project and the Activity name have to be consistent with the path and Activity name specified in the Unity project.
