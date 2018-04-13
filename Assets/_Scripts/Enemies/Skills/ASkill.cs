
public abstract class ASkill
{

	public string Name { get; set; }

	public float Damage { get; set; }

	public float Duration { get; set; }

	public bool IsActivated{ get; set; }

	public abstract void ActivateCollider (AEnemy enemy);

}
