using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray))
            {
                gameObject.SetActive(false);

            }
        }
    }
}
