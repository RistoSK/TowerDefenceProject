using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] private int _healthPoints;
    [SerializeField] private bool _isGhost;

    public void DealDamage(int damage, bool bHitGhost)
    {
        if (_isGhost)
        {
            if (bHitGhost)
            {
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }

        _healthPoints -= damage;
        
        if (_healthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetCurrentHealthPoints()
    {
        return _healthPoints;
    }
}
