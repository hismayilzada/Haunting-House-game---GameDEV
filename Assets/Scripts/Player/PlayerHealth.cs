﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth=100f;
    public static PlayerHealth PH;

    public Slider healthBarSlider;
    public Text healthText;
    [Header ("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    bool isTakingDamage=false;
    public float colorSpeed = 5f;

    public bool isDead=false;

    void Awake()
    {
        PH= this;
    }
    void Start()
    {
        healthText.text=maxHealth.ToString();
        currentHealth=maxHealth;
        healthBarSlider.value=maxHealth;
    }

    void Update()
    {
        if(currentHealth<=0) 
        {
            currentHealth=0;
        }
        if(isTakingDamage) {
            damageImage.color=damageColor;
        }
        else{
            damageImage.color=Color.Lerp(damageImage.color,Color.clear,colorSpeed*Time.deltaTime);
        }
        isTakingDamage=false;
    }

    public void DamagePlayer(float damage)
    {
        
        if(currentHealth>0) 
        {
            if(damage>=currentHealth)
            {
                isTakingDamage=true;
                Dead();
            }
            else
            {
                isTakingDamage=true;
                currentHealth-=damage;
                healthBarSlider.value-=damage;
                UpdateText();
            }
            
        }
    }

    void UpdateText() {
        healthText.text=currentHealth.ToString();
    }
    void Dead()
    {
        currentHealth=0;
        isDead=true;
        healthBarSlider.value=0;
        UpdateText();
        Debug.Log("I am dead");
    }
}
