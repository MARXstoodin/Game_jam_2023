using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireClickl : MonoBehaviour
{
    public GameObject fire;
    public GameObject babaika;
    public GameObject button;
    public AudioSource fireOff;
    public AudioClip fireOffSoundClip;

    public void FireOff()
    {
        fireOff.PlayOneShot(fireOffSoundClip);
        fire.SetActive(false);
        gameObject.SetActive(false);
        babaika.SetActive(false);
    }
}
