using UnityEditor.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
	// Singleton
	public static AudioManager S;

	public Sound[] sounds;

	void Awake ()
	{
		if (S == null) {
			S = this;
		} else {
			Destroy (gameObject);
			return;
		}

		// make AudioManager consistent between scenes
		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			// add a new AudioSource go to AudioManager
			s.source = gameObject.AddComponent<AudioSource> ();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
		}
	}


	public void Play (string name)
	{
		// find the desired sound in the sounds array
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null) {
			Debug.LogWarning (string.Format ("The AudioSource you are trying to play is null. Check if you have a typo in 'name'.\nYour input name: {0}", name));
			return;
		}
		Debug.Log ("Playing AudioSource: " + name);
		s.source.Play ();
	}
}
