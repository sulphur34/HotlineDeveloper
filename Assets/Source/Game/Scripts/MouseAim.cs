using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        // Debug.Log(mousePosition + " - " + worldPosition);
        
        transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
    }
}
