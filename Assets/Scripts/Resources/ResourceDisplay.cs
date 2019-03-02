using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{

    [SerializeField] private int _resourceAmount = 100;

    private Text _resourceAmountText;

    void Start ()
    {
        _resourceAmountText = GetComponent<Text>();
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        _resourceAmountText.text = _resourceAmount.ToString();
    }

    public void addResources(int amount)
    {
        _resourceAmount += amount;
        UpdateDisplay();
    }

    public void removeResources(int amount)
    {
        if (_resourceAmount - amount < 0) { return; }

        _resourceAmount -= amount;
        UpdateDisplay();
    }

    public int getResourcesAmount()
    {
        return _resourceAmount;
    }
}
