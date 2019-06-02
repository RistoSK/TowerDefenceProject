using UnityEngine;

[CreateAssetMenu(menuName = "Projectile Data")]
public class ProjectileData : ScriptableObject
{
    public float speed;
    public int damageAmount;
    public GameObject deathVFX;
    public float rotationSpeed;
    public bool hitGhosts;
    public bool freezeEnemies;
    [Tooltip("Freeze duration stacks every time the enemy is hit")]
    public float freezeDuration = 2f;
}
