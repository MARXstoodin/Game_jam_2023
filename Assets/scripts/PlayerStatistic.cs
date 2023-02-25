using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistic : MonoBehaviour
{
    public float HP;
    private float maxHP;
    public float Hunger;
    private float maxHunger;
    public Image hungerSlider;

    void Start()
    {
        maxHP = HP;
        maxHunger = Hunger;
    }

    void Update()
    {
        hungerSlider.fillAmount = Hunger / maxHunger;

        if(Hunger > maxHunger)
        {
            Hunger = maxHunger;
        }
        Hunger -= 1*Time.deltaTime;
    }
}
