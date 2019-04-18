using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    private void Update()
    {
        float updateSpeed = rotationSpeed * Time.deltaTime; 
        transform.Rotate(0, updateSpeed, 0);
    }
}
