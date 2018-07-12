using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour {

    public float health;
    public bool isAlive;
    private void Start()
    {
        health = 1f;
        isAlive = true;
    }

    public void Hurt()
    {
        if (health > 0f)
            health -= 0.1f;
        else
        { 
            health = 0;
            isAlive = false;
        }
    }

    public void Cure()
    {
        if (health < 1f)
            health += 0.1f;
        else
            health = 1;
    }
    public float GetHealth()
    {
        return health;
    }
}
