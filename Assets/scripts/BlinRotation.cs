using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinRotation : MonoBehaviour
{
    private float update;
    void Update()
    {
        update += Time.deltaTime;
        if (update > 0.01f)
        {
            update = 0.0f;
            transform.Rotate(0, 1, 0);
        }
    }
}
