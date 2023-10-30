[System.Serializable]
public class healthPowerup : Powerup
{
    public float healthToAdd;

    public override void Apply(PowerupManager target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.Healing(healthToAdd, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        // TODO: Remove Health changes
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(healthToAdd, target.GetComponent<Pawn>());
        }
    }
}
