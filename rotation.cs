using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
 
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Rotate the coin around its local up axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
