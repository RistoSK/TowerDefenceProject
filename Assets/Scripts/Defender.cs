using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int fruitCost;

    //TODO remove if useless
    public void AddResources(int amount)
    {
        FindObjectOfType<ResourceDisplay>().addResources(amount);
    }

    public int GetResourcesCost()
    {
        return fruitCost;
    }
}
