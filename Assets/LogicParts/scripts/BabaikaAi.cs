using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.AI;

public class BabaikaAi : MonoBehaviour
{
    public Transform Player;
    public NavMeshAgent NavMesh;
    /*public Transform Shrek;
    public Camera MainCamera;
    public GameObject FPSController;*/
    void Update()
    {
        if(NavMesh.enabled)
        {
            NavMesh.SetDestination(Player.position);
        }
    }
}