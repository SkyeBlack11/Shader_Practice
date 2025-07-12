using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBehaviour : MonoBehaviour
{
    public float spinX, spinY, spinZ;

    void Update()
    {
           transform.Rotate(spinX, spinY, spinZ);
    }
}
