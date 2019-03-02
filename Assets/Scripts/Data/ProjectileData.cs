using UnityEngine;

[CreateAssetMenu(menuName = "Projectile Data")]
public class ProjectileData : ScriptableObject
{
    public float Speed;
    public int DamageAmount;
    public GameObject DeathVFX;
    public float RotationSpeed;
}
