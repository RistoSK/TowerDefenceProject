using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private DefenderData _defenderData;
    [SerializeField] private Resource _resourcePrefab;
    [SerializeField] private Transform _spawnPosition;

    private float _remainingCooldown;
    private RaycastHit2D _hit;
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _remainingCooldown = _defenderData.SpawnCooldown;

        if (_anim == null)
        {
            Debug.Log("Animator is missing");
            return;
        }
    }

    void FixedUpdate()
    {
        // TODO make more generic (what if the attacking monster doesn't have a projectile)
        if (_defenderData.Projectile == null) { return; }

        _hit = Physics2D.Raycast(transform.position, Vector2.right, 10f, LayerMask.GetMask("Enemy"));

        if (_hit.collider == null) { return; }

        _anim.Play("Attack");
        Shoot();
    }

    // Called from animation event
    public void GenerateResources()
    {
        Instantiate(_resourcePrefab, _spawnPosition.position, transform.rotation);
    }

    void Shoot()
    {
        if (_remainingCooldown <= 0)
        {
            Instantiate(_defenderData.Projectile,  _spawnPosition.position, transform.rotation);
            _remainingCooldown = _defenderData.SpawnCooldown;
        }
        _remainingCooldown -= Time.deltaTime;
    }

    public int GetResourcesCost()
    {
        return _defenderData.Cost;
    }

    public bool isDefenderJumpable()
    {
        return _defenderData.isJumpable;
    }
}
