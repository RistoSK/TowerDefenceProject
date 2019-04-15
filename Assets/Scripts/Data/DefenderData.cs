using UnityEngine;

[CreateAssetMenu(menuName = "Defender Data")]
public class DefenderData : ScriptableObject
{
    public int cost;
    public float spawnCooldown;
    public Projectile.Projectile projectile;
    public bool isJumpable;
    public bool shouldAttackAutomatically;
}
