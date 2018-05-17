using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For effects when Xiaoxuemei uses Bladeflash
/// </summary>
public class BladeflashStateControl : MonoBehaviour
{

	public float FlashPeriod;

	private Xiaoxuemei Xiaoxuemei;
	private Player Player;
	private Light light;
	private Bladeflash Bladeflash;

	private float FacingEndTime;
	private float ChargingEndTime;
	private float FlashEndTime;

    public bool IsPlayingCharge;
    public bool IsPlayingFlash;

    public GameObject ChargeMusic;
    public GameObject FlashMusic;

	void Start ()
	{
		Xiaoxuemei = gameObject.GetComponentInParent<Xiaoxuemei> ();
		Player = GameObject.Find ("Player").GetComponent<Player> ();
		light = gameObject.GetComponent<Light> ();
		light.enabled = false;
        IsPlayingCharge = false;
        IsPlayingFlash = false;
        FlashEndTime = 0f;

		//StartCoroutine (WaitForNextBlink ());
	}


	void Update ()
	{
        
		if (Xiaoxuemei.CurrentSkill.Name.Equals ("Bladeflash")) {
			Bladeflash = (Bladeflash)Xiaoxuemei.CurrentSkill;
			FacingEndTime = Bladeflash.FacingEndTime;
			ChargingEndTime = Bladeflash.ChargingEndTime;
			FlashEndTime = Bladeflash.FlashEndTime;
		}
        if (FlashEndTime != 0f && Time.time <= ChargingEndTime)
        {
            if (!IsPlayingCharge)
            {
                Instantiate(ChargeMusic);
                IsPlayingCharge = true;
            }
            light.enabled = !light.enabled;
            IsPlayingFlash = false;
            return;
        }
        IsPlayingCharge = false;
        if (FlashEndTime != 0f && Time.time <= FlashEndTime && !IsPlayingFlash) {
            Debug.Log("Else If");
            Instantiate(FlashMusic);
            IsPlayingFlash = true;
            return;
        }
        Debug.Log("Outside");
        light.enabled = false;
    }

}
