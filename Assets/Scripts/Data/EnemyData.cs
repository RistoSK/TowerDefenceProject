using UnityEngine;

//[Flags] , mporousa na to kanw kai list ama thelw na exw polla
public enum EnemyType
{
    Default = 1 << 0,
    Jump = 1 << 1,
    Ghost = 1 << 2
}

[CreateAssetMenu(menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public int damage;
    public float attackCooldown;
    public float speed;
    public float frozenSpeed;
    public EnemyType type;
}
