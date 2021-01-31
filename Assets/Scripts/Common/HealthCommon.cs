using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCommon : MonoBehaviour
{

    public float baseHealth,lifeRegen,lifeRegenTimer,currentHealth;
    
    private float lifeRegenTimerControl;

    void Start()
    {
        currentHealth = baseHealth;
    }

    public void takeDamage(float damage)
    {
        if ((currentHealth - damage)>0)
        {
            currentHealth -= damage;
        }
        else
        {
            die();
        }
        
    }

    void regenLife()
    {

        if (currentHealth < baseHealth && Time.time >= lifeRegenTimerControl)
        {

            lifeRegenTimerControl = Time.time + lifeRegenTimer;

            if ((currentHealth + lifeRegen)>baseHealth)
            {
                currentHealth = baseHealth;
            }
            else
            {
                currentHealth += lifeRegen;
            }
        }
    }

    void die()
    {
        Destroy(this.gameObject);
    }


}
