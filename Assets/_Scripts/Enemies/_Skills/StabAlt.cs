public class StabAlt : ASkill
{

	public StabAlt ()
	{
		Name = "Stab";
		Damage = 10.0f;
		Duration = .6f;
		IsActivated = false;
	}

	public override void ActivateCollider (AEnemy enemy)
	{
		
	}
}

