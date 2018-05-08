using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour {
	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Slider bgmVolumeSlider;
	public GameSettings gameSettings;

	public Resolution[] resolutions;

	void OnEnable() {
		gameSettings = new GameSettings ();


		resolutions = Screen.resolutions;
	}

	public void onFullscreenToggle() {
		
	}

	public void onResolutionChange(){

	}

	public void onTextureQualityChange() {

	}

	public void onBgmVolumeChange(){

	}

	public void saveSettings() {

	}

	public void loadSettings() {

	}
}
