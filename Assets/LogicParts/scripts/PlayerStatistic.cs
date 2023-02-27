using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatistic : MonoBehaviour
{
    public float HP;
    private float maxHP;
    public float Hunger;
    public float maxHunger;
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
        if(Hunger <= 0)
        {
            Hunger = 0;
        }
        Hunger -= 0.5f * Time.deltaTime;
    }

    public void GetDamage()
    {

    }

    public void Die()
    {

    }
}
