using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinRotation : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        transform.Rotate(speed, 0, 0);
    }
}
