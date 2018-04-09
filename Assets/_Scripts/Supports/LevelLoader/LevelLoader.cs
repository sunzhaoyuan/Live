using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{

	[Header ("Call LoadLevel when loading a scene.")]
	public GameObject loadingScreen;
	public Slider slider;


	/// <summary>
	/// Call this method to load a scene by its name.
	/// </summary>
	///
	/// <param name="sceneToLoad">
	/// 	Name of the Scene to load.
	/// </param>
	public void LoadLevel (string sceneToLoad)
	{
		StartCoroutine (LoadAsynchronously (sceneToLoad));
		StartCoroutine (FadeScene ());
	}

	private IEnumerator FadeScene ()
	{
		// Fading from dark
		float fadeTime = gameObject.GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
	}


	/// <summary>
	/// 	Loads the scene and reports the Progress constently untile it's done.
	/// </summary>
	///
	/// <param name="sceneToLoad">
	///		Name of the Scene to load.
	/// </param>
	private IEnumerator LoadAsynchronously (string sceneToLoad)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneToLoad);
		loadingScreen.SetActive (true);

		while (!operation.isDone) {
			// Clamp progress from .9 to 1.
			float progress = Mathf.Clamp01 (operation.progress / .9f);
			Debug.Log (progress);
			// update progress with slider
			slider.value = progress;

			yield return null;
		}

	}
}
