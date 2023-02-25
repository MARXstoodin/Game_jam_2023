using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorBlinov : MonoBehaviour
{
    public GameObject BlinP;
    public GameObject Terrain;
    void Start()
    {
        for(int x = 0; x < 1000; x++)
        {
            for(var y = 0; y < 1000; y++)
            {
                int rnd = Random.Range(0, 10000);
                if (rnd == 1)
                {
                    GameObject Blin = Instantiate(BlinP, new Vector3(x, 1, y), transform.rotation);
                }
            }
        }
    }
}
