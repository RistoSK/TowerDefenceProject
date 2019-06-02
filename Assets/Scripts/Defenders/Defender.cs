using System.Collections;
using System.Collections.Generic;
using Resources;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private DefenderData defenderData;

    [Header("Optional Settings")]
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Resource resourcePrefab;
    [SerializeField] private GameObject reloadBar;
    [SerializeField] private Transform reloadBarTransform;

    private float _remainingCooldown;
    private RaycastHit2D _hit;
    private Animator _anim;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _remainingCooldown = 0;

        if (_anim == null)
        {
            Debug.Log("Animator is missing");
            return;
        }
    }

    void FixedUpdate()
    {
        // TODO make more generic (what if the attacking monster doesn't have a projectile)

        if (defenderData.projectile == null)
        {
            return;
        }

        if (defenderData.shouldAttackAutomatically)
        {
            _hit = Physics2D.Raycast(transform.position, Vector2.right, 10f, LayerMask.GetMask("Enemy"));

            //if (!_hit.collider.isActiveAndEnabled)
            if (_hit.collider == null)
            {
                return;
            }

            _anim.Play("Attack");
            Shoot();
        }
        else
        {
            ShootWithCoolDown();
        }
    }

    private void ShootWithCoolDown()
    {
        if (_remainingCooldown <= 0)
        {
            reloadBar.gameObject.SetActive(false);
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(defenderData.projectile, spawnPosition.position, transform.rotation);
                _anim.Play("Attack");
                _remainingCooldown = defenderData.spawnCooldown;
            }
        }
        else
        {
            reloadBar.gameObject.SetActive(true);
            _remainingCooldown -= Time.deltaTime;
            reloadBarTransform.localScale = new Vector3(_remainingCooldown / defenderData.spawnCooldown, 1);
        }
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
