using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    EnemyAI enemy;
    public GameObject bloodEffect;
  
    void Start()
    {
        enemy=GetComponent<EnemyAI>();
    }

   
    void Update()
    {
        if(enemyHealth<=0) 
        {
           enemyHealth=0;
        }
    }

    public void ReduceHealth(float reduceHealth)
    {
        enemyHealth -= reduceHealth;
        if(!enemy.isDead)
        {
            enemy.Hurt();
        }

        if (enemyHealth <= 0)
        {
            Dead();
            enemy.DeadAnim();
            
        }
    }

    void Dead()
    {
        bloodEffect.SetActive(true);
        enemy.canAttack=false;
        Destroy(gameObject, 3f);
    }
}
