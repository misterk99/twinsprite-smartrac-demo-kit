# Twinsprite & SMARTRAC Demo Kit


The Twinsprite & SMARTRAC Demo Kit illustrates the integration of toys in mobile games developed with Unity 3D, using the [Twinsprite Plataform](http://developers.twinsprite.com) and NFC tags or QR codes to store a code (ToyxID) that identifies uniquely each toy.

## Project Page

[http://demokit.twinsprite.com](http://demokit.twinsprite.com)

## Repository Content

This repository includes five Unity Projects:

* [/UnityProject](https://github.com/twisprite-developers/twinsprite-smartrac-demo-kit/tree/master/UnityProject): this is the Glorten's Dungeon Unity game for iOS and Android. It is a dungeon crawler mini game that interacts with a NFC trading card you can request in the project page. The project illustrates the usage of the NFC and QR plugins to scan the card identity and the interaction with the Twinsprite API to retrieve and update the data attached to the card.
* [/Unity-iOS-QR-Plugin](https://github.com/twisprite-developers/twinsprite-smartrac-demo-kit/tree/master/Unity-iOS-QR-Plugin): this is a Unity demo project with a QR reader plugin for iOS.
* [/Unity-Android-QR-Plugin](https://github.com/twisprite-developers/twinsprite-smartrac-demo-kit/tree/master/Unity-Android-QR-Plugin): this is a Unity demo project with an Android QR reader plugin based on the ZXing scanner.
* [/Unity-Android-NFC-Plugin](https://github.com/twisprite-developers/twinsprite-smartrac-demo-kit/tree/master/Unity-Android-NFC-Plugin): this is a Unity demo project with an Android NFC reader plugin.
* [Unity-All-Plugins](https://github.com/twisprite-developers/twinsprite-smartrac-demo-kit/tree/master/Unity-All-Plugins): this is a Unity demo project that integrates all the previous plugins to read and scan NFC and QR codes with Android and iOS devices.

## Play Now
If you want to test the game before digging into the project code, there is a precompiled version of the Glorten's Dungeon app available on [Google Play](https://play.google.com/store/apps/details?id=com.twinsprite.dungeondemokit)

You can generate a playable identity (like the ones included in the physical Glorten cards) in the [Demo Kit project page](http://demokit.twinsprite.com/#trynow).

## Unity Project Quick Start


*Note: Unity PRO is required.*

1. Donwload the [/UnityProject](https://github.com/twisprite-developers/twinsprite-smartrac-demo-kit/tree/master/UnityProject) and import it in Unity 3D, the project requires the Unity PRO version. Open the **menu scene** and select the **ToyxManager** GameObject, in the Inspector tab, under the Toyx Manager Script you will find the game keypair (**API_KEY**, **SECRET_KEY**) and the **Toyx Id** fields, the default values for Glorten attributes and a set of buttons to fire and debug the Twinsprite API while you are running the game. 
2. Register on the [Twinsprite Development Portal](http://devportal.twinsprite.com/register). Under **GAME > My Games** you will find the demo kit game. Assign your game keypair (the **API Key** and **Secret Key** fields of the game) to the **API_KEY** and **SECRET_KEY** fields of the editor (The default values are the keypair of the public app available on Google Play, use it if you want to play the game with the codes generated in the demo page instead of your own codes).
3. Generate Toyx of your Glorten Model: under **DEVELOPMENT TOYX > Create new Toyx** select a name and generate a new batch of development toyx, that represent instances of the Glorten toy in the Twinsprite backend. Now copy the Toyx ID of one of your toyx and assign its value to the variable **Toyx Id** field in the **ToyxManager** editor.
4. Run the **menu scene** and click *PLAY*, your glorten toy should be loaded. Use the **Toyx Manager** editor to debug the Twinsprite SDK calls.
5. Now you can build the project for iOS or Android.

## Other Development Resources

Twinsprite Developers: [http://developers.twinsprite.com](http://developers.twinsprite.com)

Twinsprite Development Portal: [http://devportal.twinsprite.com](http://devportal.twinsprite.com)

Twinsprite API: [https://api.twinsprite.com](https://api.twinsprite.com)