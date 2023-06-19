using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

 
    public float enemyHealth = 100;
  
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void reduceHealth(float val)
    {
        enemyHealth = enemyHealth-val;
        if (enemyHealth <= 0)
        {
            dead();
        }
    }

    void dead()
    {
        Destroy(gameObject);
    }
}
