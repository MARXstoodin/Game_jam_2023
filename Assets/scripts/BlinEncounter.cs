using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinEncounter : MonoBehaviour
{
    public PlayerStatistic ps;
    public float HealFromOnePuncake;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "blin")
        {
            Destroy(other.gameObject);
            ps.Hunger += HealFromOnePuncake;
        }
    }
}
