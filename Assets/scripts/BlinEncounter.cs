using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlinEncounter : MonoBehaviour
{
    public PlayerStatistic ps;
    public float HealFromOnePuncake;
    public Transform Shrek;
    public Camera MainCamera;
    public GameObject FPSController;
    public NavMeshAgent NavMesh;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "blin")
        {
            print("s");
            Destroy(other.gameObject);
            ps.Hunger += HealFromOnePuncake;
        }
        if (other.tag == "Babika")
        {
            //print("Death");
            FPSController.GetComponent<SC_FPSController>().enabled = false;
            StartCoroutine(RotateTowardsTarget());
            StartCoroutine(RotateTowardsTarget2());
            enabled = false;
        }
    }
    IEnumerator RotateTowardsTarget()
    {
        //print("CoroutineCheck1");
        var duration = 2.0;

        // store the initial and target rotation once
        var startRotation = MainCamera.transform.rotation;
        var targetRotation = Quaternion.LookRotation(new Vector3(Shrek.position.x, Shrek.position.y + 3, Shrek.position.z) - MainCamera.transform.position);

        for (var timePassed = 0.0f; timePassed < duration; timePassed += Time.deltaTime)
        {
            var factor = timePassed / duration;
            // optionally add ease-in and -out
            factor = Mathf.SmoothStep(0, 3, (float)factor);
            NavMesh.enabled = false;
            MainCamera.transform.rotation = Quaternion.Slerp(startRotation, targetRotation, (float)factor);
            yield return null;
        }

        // just to be sure to end up with clean values
        MainCamera.transform.rotation = targetRotation;
    }
    IEnumerator RotateTowardsTarget2()
    {
        //print("CoroutineCheck2");
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
    }
}
