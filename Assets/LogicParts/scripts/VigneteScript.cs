using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigneteScript : MonoBehaviour
{
    private Image vignete;
    public Color tempColor;

    [Range (0f, 1f)]
    public float Intensity;

    void Start()
    {
        vignete = GetComponent<Image>();
    }

    void Update()
    {
        tempColor.a = Intensity;
        vignete.color = tempColor;
    }
}
