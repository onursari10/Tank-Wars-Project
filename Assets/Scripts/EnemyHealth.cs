using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int enemyHealth = 10;
    public int healthCounter;

   public bool isDestroyed = false;

  


    void Awake()
    {
       
    }

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            enemyDestroyed();
        }
    }
    public void TakeHit(int amount)
    {

        enemyHealth -= amount;
       

    }

    void enemyDestroyed()
    {
        isDestroyed = true;
    }

}
