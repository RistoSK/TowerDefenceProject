using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int HealthPoints = 100;

    public void DealDamage(int damage)
    {
        HealthPoints -= damage;
        
        if (HealthPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int GetCurrentHealthPoints()
    {
        return HealthPoints;
    }
}
