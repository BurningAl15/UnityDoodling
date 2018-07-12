using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            PlayerBehaviour.isAlive = false;
        }

        if (collision.tag.Equals("Obstacle"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag.Equals("Rain"))
        {
            Destroy(collision.gameObject);
           
        }

    }
}
