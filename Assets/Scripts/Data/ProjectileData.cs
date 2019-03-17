using UnityEngine;

[CreateAssetMenu(menuName = "Projectile Data")]
public class ProjectileData : ScriptableObject
{
    public float speed;
    public int damageAmount;
    public GameObject deathVFX;
    public float rotationSpeed;
}
