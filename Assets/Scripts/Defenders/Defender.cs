using System.Collections;
using System.Collections.Generic;
using Resources;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private DefenderData defenderData;
    [SerializeField] private Resource resourcePrefab;
    [SerializeField] private Transform spawnPosition;

    private float _remainingCooldown;
    private RaycastHit2D _hit;
    private Animator _anim;

    void Start()
    {
        if (defenderData.projectile == null)
        {
            Debug.LogError("Defender data projectile is null");
        }

        _anim = GetComponent<Animator>();
        _remainingCooldown = defenderData.spawnCooldown;

        if (_anim == null)
        {
            Debug.Log("Animator is missing");
            return;
        }
    }

    void FixedUpdate()
    {
        // TODO make more generic (what if the attacking monster doesn't have a projectile)

        _hit = Physics2D.Raycast(transform.position, Vector2.right, 10f, LayerMask.GetMask("Enemy"));

        if (!_hit.collider.isActiveAndEnabled) { return; }

        _anim.Play("Attack");
        Shoot();
    }

    // Called from animation event
    public void GenerateResources()
    {
        Instantiate(resourcePrefab, spawnPosition.position, transform.rotation);
    }

    private void Shoot()
    {
        if (_remainingCooldown <= 0)
        {
            Instantiate(defenderData.projectile,  spawnPosition.position, transform.rotation);
            _remainingCooldown = defenderData.spawnCooldown;
        }
        _remainingCooldown -= Time.deltaTime;
    }

    public int GetResourcesCost()
    {
        return defenderData.cost;
    }

    public bool IsDefenderJumpable()
    {
        return defenderData.isJumpable;
    }
}
