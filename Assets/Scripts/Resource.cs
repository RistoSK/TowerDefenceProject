using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    //[SerializeField] Sprite[] sprites;
    [SerializeField] int resourcePoints;
    [SerializeField] float resourceSpeed;
    [SerializeField] float resourceLifeTime;
     
    void Start()
    {
        Destroy(gameObject, resourceLifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.up * resourceSpeed * Time.deltaTime);
        transform.localScale += new Vector3(0.003f, 0.003f);
    }

    private void OnMouseDown()
    {
        AddResources(resourcePoints);
        Destroy(gameObject);
    }

    private void AddResources(int amount)
    {
        if (FindObjectOfType<ResourceDisplay>() == null)
        {
            Debug.Log("Resource display is missing");
            return;
        }
        FindObjectOfType<ResourceDisplay>().addResources(amount);
    }
}

