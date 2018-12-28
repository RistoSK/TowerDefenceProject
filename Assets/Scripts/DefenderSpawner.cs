using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    Vector2 clickPos;
    Vector2 worldPos;
    Vector2 gridPos;

    DefenderSelecter defenderSelecter;
    ResourceDisplay resourceDisplay;

    private void Start ()
    {
        defenderSelecter = FindObjectOfType<DefenderSelecter>();
        resourceDisplay = FindObjectOfType<ResourceDisplay>();
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void OnMouseDown ()
    {
        if (defender == null)
        {
            Debug.Log("Defender is missing");
            return;
        }

        PlaceDefender(GetSquareClicked());
      
        if (defenderSelecter == null)
        {
            Debug.Log("DefenderSelecter is null");
            return;
        }
        defenderSelecter.DisableDefenderSelecterColors();
    }

    private Vector2 GetSquareClicked()
    {
        clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        gridPos = FitToGrid(worldPos);

        return gridPos;
    }

    private Vector2 FitToGrid(Vector2 worldPos)
    {
        float newX = Mathf.RoundToInt(worldPos.x);
        float newY = Mathf.RoundToInt(worldPos.y);

        return new Vector2(newX, newY);
    }

    private void PlaceDefender(Vector2 spawnPosition)
    {
        //TODO remove maybe var amountDisplay = FindObjectOfType<DefenderSelecter>();
        int defenderCost = defender.GetResourcesCost();

        if (defenderCost < resourceDisplay.getResourcesAmount())
        {
            resourceDisplay.removeResources(defenderCost);
            Defender defenderToSpawn = Instantiate(defender, spawnPosition, transform.rotation);
            // De-select the defender from the list so the user has to click it again
            defender = null;
        }
    }
}
