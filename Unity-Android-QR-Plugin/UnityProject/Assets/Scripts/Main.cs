using UnityEngine;
using System.Collections;


public class Main : MonoBehaviour {

	string qrString = "";

	void OnGUI () {

		// Scan QR button
		if(GUI.Button(new Rect(20,40,300,300), "ScanQR")) {
			AndroidQRReader.ScanQR(gameObject.name, "OnFinishScan");
		}

		GUI.Label(new Rect(20,360,300,300), "Result: "+qrString);

	}

	// QR callback
	void OnFinishScan(string result) {

		// Cancelled
		if (result == AndroidQRReader.CANCELLED) {

		// No software
		} else if (result == AndroidQRReader.NO_SOFTWARE) {

		// Error
		} else if (result == AndroidQRReader.ERROR) {
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
