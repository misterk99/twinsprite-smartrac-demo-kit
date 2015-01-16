# Unity-Android NFC Plugin

## Usage

1. Copy the **Plugins** folder into your Unity project.
2. To launch the NFC reader run *NFCReader.ScanNFC(Object_Name, Method_Name)*
3. In the *Object_Name* object implement the *Method_Name* callBack function called when a new tag is read.

The script *Main.cs* includes a running example.

## Content

**/Scripts/Mai**

Demo script that fires the method to scan a NFC tag.

**/Plugins/AndroidNFCReader**

Script that fires a native event to scan y read the result.

**/Pugings/Android**

It includes a .jar file generated using the eclipse project in *EclipseProject* folder and the corresponding manifest file. The absolute path of the main package in the eclipse project and the Activity name have to be consistent with the path and Activity name specified in the Unity project.

