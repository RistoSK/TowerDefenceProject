using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int Damage;
    public float AttackCooldown;
    public float Speed;
    public bool ShouldJump;
}
