package com.twinsprite.demokit.androidQR;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;

public class ScanActivity extends UnityPlayerActivity {

	// Callback object and method
	String gameObject;
	String methodName;


	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
	}

	public void scanQR(String gameObject, String methodName) {

		// Save callback object and method
		this.gameObject = gameObject;
		this.methodName = methodName;

		runOnUiThread(new Runnable() {

			@Override
			public void run() {
				try {

					Intent intent = new Intent("com.google.zxing.client.android.SCAN");
					intent.putExtra("SCAN_MODE", "QR_CODE_MODE");
					startActivityForResult(intent, 0);

				} catch (Exception e) {

					Uri marketUri = Uri.parse("market://details?id=com.google.zxing.client.android");
					Intent marketIntent = new Intent(Intent.ACTION_VIEW,marketUri);
					startActivity(marketIntent);

					// Send no software message
					UnityPlayer.UnitySendMessage(ScanActivity.this.gameObject, 
												ScanActivity.this.methodName, "NO_SOFTWARE");
				}

			}
		});


	}


	protected void onActivityResult(int requestCode, int resultCode, Intent data) {           
		super.onActivityResult(requestCode, resultCode, data);

		if (requestCode == 0) {
			if (resultCode == RESULT_OK) {
				String contents = data.getStringExtra("SCAN_RESULT");
				UnityPlayer.UnitySendMessage(gameObject, methodName, contents);
			} else {
				UnityPlayer.UnitySendMessage(gameObject, methodName, "CANCELLED");
			}
		}
	}
}