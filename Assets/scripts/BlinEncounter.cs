using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinEncounter : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
