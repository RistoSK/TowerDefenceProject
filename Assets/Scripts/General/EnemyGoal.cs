using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoal : MonoBehaviour
{
    private Level level;

    void Start()
    {
        level = FindObjectOfType<Level>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null)
        {
            level.GameOver();
        }
    }
}
