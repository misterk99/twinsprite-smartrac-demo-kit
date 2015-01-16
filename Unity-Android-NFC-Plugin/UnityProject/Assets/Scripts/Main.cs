using UnityEngine;
using System.Collections;


public class Main : MonoBehaviour {

	string qrString = "";

	void OnGUI () {

		// Scan NFC button
		if(GUI.Button(new Rect(20,40,300,300), "ScanNFC")) {
			AndroidNFCReader.ScanNFC(gameObject.name, "OnFinishScan");
		}

		GUI.Label(new Rect(20,360,300,300), "Result: "+qrString);

	}

	// QR callback
	void OnFinishScan(string result) {

		// Cancelled
		if (result == AndroidNFCReader.CANCELLED) {
		
		// Error
		} else if (result == AndroidNFCReader.ERROR) {
		

		// No hardware
		} else if (result == AndroidNFCReader.NO_HARDWARE) {
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
