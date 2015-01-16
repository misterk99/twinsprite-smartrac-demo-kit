using UnityEngine;
using System.Collections;

public class AndroidQRReader : MonoBehaviour {

	static public readonly string ERROR = "ERROR";
	static public readonly string NO_SOFTWARE = "NO_SOFTWARE";
	static public readonly string CANCELLED = "CANCELLED";
	static public readonly string NO_ALLOWED_OS = "NO_ALLOWED_OS";

	public static void ScanQR(string objectName, string functionName) {

		switch (Application.platform) {
			
		case RuntimePlatform.Android:
			AndroidJavaClass javaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
			AndroidJavaObject javaObject = javaClass.GetStatic<AndroidJavaObject>("currentActivity"); 
			javaObject.Call("scanQR",objectName,functionName);
			break;

		default:		
			GameObject.Find(objectName).SendMessage(functionName, NO_ALLOWED_OS);
			break;
		}
	}
}
