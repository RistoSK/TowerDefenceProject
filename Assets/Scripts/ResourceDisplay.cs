using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{

    [SerializeField] int resourceAmount = 100;

    Text resourceAmountText;

    void Start ()
    {
        resourceAmountText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        resourceAmountText.text = resourceAmount.ToString();
    }

    public void addResources(int amount)
    {
        resourceAmount += amount;
        UpdateDisplay();
    }

    public void removeResources(int amount)
    {
        if (resourceAmount - amount < 0) { return; }

        resourceAmount -= amount;
        UpdateDisplay();
    }

    public int getResourcesAmount()
    {
        return resourceAmount;
    }
}
