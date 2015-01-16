package com.twinsprite.dungeondemokit;

import android.app.Activity;
import android.app.PendingIntent;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.IntentFilter.MalformedMimeTypeException;
import android.net.Uri;
import android.nfc.NfcAdapter;
import android.nfc.tech.NfcF;
import android.os.Bundle;

import com.unity3d.player.UnityPlayer;
import com.unity3d.player.UnityPlayerActivity;

public class ScanActivity extends UnityPlayerActivity {

	// Callback object and method
	private String gameObject;
	private String methodName;

	private NfcAdapter mAdapter = null;
	private PendingIntent mPendingIntent;
	private IntentFilter[] mFilters;
	private String[][] mTechLists;

	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		// Create NFC Adapter
		mAdapter = NfcAdapter.getDefaultAdapter(this);

		// Pending intent
		mPendingIntent = PendingIntent.getActivity(this, 0,
				new Intent(this, ScanActivity.class).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);

		// Setup a tech list for all NfcF tags
		mTechLists = new String[][] { new String[] { NfcF.class.getName() } };   

		// Setup an intent filter for all MIME based dispatches (TEXT);
		IntentFilter ndefText = new IntentFilter(NfcAdapter.ACTION_NDEF_DISCOVERED);
		try {
			ndefText.addDataType("*/*");
		} catch (MalformedMimeTypeException e) {
		}		

		// Setup an intent filter for all MIME based dispatches (URI);
		IntentFilter ndefURI = new IntentFilter(NfcAdapter.ACTION_NDEF_DISCOVERED);
		ndefURI.addDataScheme("http");
		ndefURI.addDataScheme("https");

		mFilters = new IntentFilter[] { ndefText, ndefURI};	
	}

	public void scanNFC(String gameObject, String methodName) {

		// Save callback object and method
		this.gameObject = gameObject;
		this.methodName = methodName;

		// No hardware
		if (mAdapter == null) {
			UnityPlayer.UnitySendMessage(ScanActivity.this.gameObject, 
					ScanActivity.this.methodName, "NO_HARDWARE");
			return;
		}

		runOnUiThread(new Runnable() {

			@Override
			public void run() {
				Intent intent = new Intent(ScanActivity.this,ScanNFCActivity.class);					
				startActivityForResult(intent, 0);
			}
		});
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

	@Override
	public void onResume() {
		if (mAdapter != null) {
			mAdapter.enableForegroundDispatch(this, mPendingIntent, mFilters, mTechLists);
		}	  
		super.onResume();
	}

	@Override
	public void onPause() {
		if (mAdapter != null) {
			mAdapter.disableForegroundDispatch(this);
		}
		super.onPause();	
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