using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class IOSQRReader {

	public static readonly string CANCELLED = "CANCELLED";
	public static readonly string ERROR = "ERROR";
	static public readonly string NO_ALLOWED_OS = "NO_ALLOWED_OS";


	[DllImport ("__Internal")]
	private static extern void _ScanQR (string objectName, string functionName);

	

	public static void ScanQR(string objectName, string functionName) {
	
		switch (Application.platform) {
		case RuntimePlatform.IPhonePlayer:

			_ScanQR(objectName, functionName);
			break;

		default:
			GameObject.Find(objectName).SendMessage(functionName, NO_ALLOWED_OS);
			break;
		}

	}

}
