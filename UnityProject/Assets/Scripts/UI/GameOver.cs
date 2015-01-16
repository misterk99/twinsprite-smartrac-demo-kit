using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public GameObject contentPanel;
	public Image loadingSpinner;
	public AudioClip GameOverAudioClip;

	void Start ()
	{
		AudioSource.PlayClipAtPoint(GameOverAudioClip, Camera.main.transform.position);
	}

	public void OnClickRetry() {

		// Hide content pane
		contentPanel.SetActive(false);

		// Show spinner
		loadingSpinner.gameObject.SetActive(true);

		// Load level
		StartCoroutine(LoadGame("game"));


	}

	public void OnClickHome() 
	{

		// Save toyx if toyxmanager exists
		GameObject toyxManagerGameObject = GameObject.Find("ToyxManager");
		if (toyxManagerGameObject != null)
		{
			ToyxManager toyxManager = toyxManagerGameObject.GetComponent<ToyxManager>();
			toyxManager.Save(null);
		}

		// Hide content pane
		contentPanel.SetActive(false);
		
		// Show spinner
		loadingSpinner.gameObject.SetActive(true);
		
		// Load level
		StartCoroutine(LoadGame("menu"));

	}

	IEnumerator LoadGame(string scene) {
		AsyncOperation async = Application.LoadLevelAsync(scene);		
		while (!async.isDone) {
			
			// Spinner
			loadingSpinner.rectTransform.eulerAngles = new Vector3(loadingSpinner.rectTransform.eulerAngles.x,loadingSpinner.rectTransform.eulerAngles.y, loadingSpinner.rectTransform.eulerAngles.z - 3);
			
			yield return null;
		}
	}

}
