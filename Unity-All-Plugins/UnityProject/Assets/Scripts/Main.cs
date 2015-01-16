using UnityEngine;
using System.Collections;


public class Main : MonoBehaviour {

	string qrString = "";

	void OnGUI () {

		// Scan QR button
		if(GUI.Button(new Rect(20,40,300,300), "ScanQR")) {
			Reader.ScanQR(gameObject.name, "OnFinishScan");
		}

		// Scan NFC button
#if UNITY_ANDROID
		if(GUI.Button(new Rect(20,380,300,300), "ScanNFC")) {
			Reader.ScanNFC(gameObject.name, "OnFinishScan");
		}
#endif

		GUI.Label(new Rect(20,720,300,300), "Result: "+qrString);

	}

	// QR callback
	void OnFinishScan(string result) {

		// Cancelled
		if (result == Reader.CANCELLED) {
		
		// Error
		} else if (result == Reader.ERROR) {
		
		// No software
		} else if (result == Reader.NO_SOFTWARE) {
		
		// No hardware
		} else if (result == Reader.NO_HARDWARE) {
		}


		qrString = getToyxFromUrl(result);
	}

	// Extract toyxId from url
	string getToyxFromUrl(string url) {		
		int index = url.LastIndexOf('/') + 1;
		
		if (url.Length > index) {
			return url.Substring(index);		
		} 
		
		return url;
	}

}
