
public class Stab : ASkill
{

	public Stab ()
	{
		Name = "FrontHit";
		Damage = 30.0f;
		Duration = 1.0f;
		IsActivated = false;
	}

	public override void ActivateCollider (AEnemy enemy)
	{
		
	}
}
