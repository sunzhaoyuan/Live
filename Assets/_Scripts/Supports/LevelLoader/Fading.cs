using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
	[Header ("Set in the Inspector")]
	// The texture that will overlay the screen
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	[SerializePrivateVariables]
	// The texture's order in the draw hierarchy: a low number means it renders on top
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	// fade in = -1 or out  = 1
	private int fadeDir = -1;


	void OnGUI ()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		// force number between 0 and 1. GUI.color users alpha values between 0 and 1
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}


	/// <summary>
	/// Begins the fading.
	/// </summary>
	/// <returns>
	/// 	The fadeSpeed variable so it's easy to time the LoadLevel().
	/// </returns>
	/// <param name="direction"> Direction. </param>
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return fadeSpeed;
	}


	/// <summary>
	/// OnLevelWasLoaded is called when a level is loaded. 
	/// </summary>
	void OnLevelWasLoaded ()
	{
		BeginFade (-1);
	}


}
