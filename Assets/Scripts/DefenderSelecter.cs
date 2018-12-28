using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSelecter : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;

    DefenderSpawner defenderSpawner;
    DefenderSelecter[] defenders;

    private void Start ()
    {
        defenderSpawner = FindObjectOfType<DefenderSpawner>();
       
    }

	private void OnMouseDown ()
    {
        if (defenderSpawner == null)
        {
            Debug.Log("Defender is missing");
            return;
        }

        DisableDefenderSelecterColors();

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    public void DisableDefenderSelecterColors()
    {
        defenders = FindObjectsOfType<DefenderSelecter>();
        if (defenders == null)
        {
            Debug.Log("Defenders[] is null");
            return;
        }

        foreach (DefenderSelecter defender in defenders)
        {
            defender.GetComponent<SpriteRenderer>().color = new Color32(100, 100, 100, 255);
        }
    }
}
