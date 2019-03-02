using UnityEngine;

[CreateAssetMenu(menuName = "Defender Data")]
public class DefenderData : ScriptableObject
{
    public int Cost;
    public float SpawnCooldown;
    public Projectile Projectile;
    public bool isJumpable;
}
