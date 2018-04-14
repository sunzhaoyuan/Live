

public class Stab : ASkill
{

	public Stab ()
	{
		Name = "Stab";
		Damage = 10.0f;
		Duration = 3.0f;
		IsActivated = false;
	}

	public override void ActivateCollider (AEnemy enemy)
	{
		
	}
}
