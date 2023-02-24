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
    //public Transform Shrek;
    //public Camera MainCamera;
    //public GameObject FPSController;
    void Update()
    {
        NavMesh.SetDestination(Player.position);
        /*if (System.Math.Sqrt(System.Math.Pow(Shrek.position.z - Player.position.z, 2) + System.Math.Pow(Shrek.position.x - Player.position.x, 2)) < 2)
        {
            Animation.SetTrigger("Scream");
            print("Death");
            FPSController.GetComponent<SC_FPSController>().enabled = false;
            StartCoroutine(RotateTowardsTarget());
            StartCoroutine(RotateTowardsTarget2());
            NavMesh.enabled = false;
            //MainCamera.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(Shrek.position.x, Shrek.position.y + 3, Shrek.position.z)), Time.time * 9);
            //MainCamera.transform.LookAt(new Vector3(Shrek.position.x, Shrek.position.y + 3, Shrek.position.z));
            enabled = false;
        }*/
    }
    /*IEnumerator RotateTowardsTarget()
    {
        print("CoroutineCheck");
        var duration = 2.0;

        // store the initial and target rotation once
        var startRotation = MainCamera.transform.rotation;
        var targetRotation = Quaternion.LookRotation(new Vector3(Shrek.position.x, Shrek.position.y + 3, Shrek.position.z) - MainCamera.transform.position);

        for (var timePassed = 0.0f; timePassed < duration; timePassed += Time.deltaTime)
        {
            var factor = timePassed / duration;
            // optionally add ease-in and -out
            factor = Mathf.SmoothStep(0, 3, (float)factor);

            MainCamera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, (float)factor);
            yield return null;
        }

        // just to be sure to end up with clean values
        MainCamera.transform.rotation = targetRotation;
    }
    IEnumerator RotateTowardsTarget2()
    {
        print("CoroutineCheck");
        var duration = 2.0;

        // store the initial and target rotation once
        var startRotation = Shrek.rotation;
        var targetRotation = Quaternion.LookRotation(new Vector3(MainCamera.transform.position.x, Shrek.position.y, MainCamera.transform.position.z) - Shrek.position);

        for (var timePassed = 0.0f; timePassed < duration; timePassed += Time.deltaTime)
        {
            var factor = timePassed / duration;
            // optionally add ease-in and -out
            factor = Mathf.SmoothStep(0, 5, (float)factor);

            Shrek.rotation = Quaternion.Slerp(startRotation, targetRotation, (float)factor);
            yield return null;
        }

        // just to be sure to end up with clean values
        Shrek.rotation = targetRotation;
    }*/
}