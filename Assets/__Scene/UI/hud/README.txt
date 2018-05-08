add following things to playerControl.cs

[Header ("Set in Inspector")]	
//by liq
	public Image uitHPbar;
	public Text uitBuff;

	void Start ()
	{	
		CurrentHP = 30;
		...
	}
	void Update ()
	{	...
		//by liq
		uitHPbar.fillAmount = CurrentHP/100f;
		uitBuff.text="Buff: "+Buff.Name;

	}