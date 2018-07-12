using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed,max,min;

    TopDownPlayer player;
    float distance;
    LineRenderer line;
    public Material mat;
    PlayerHealth health;
	// Use this for initialization
	void Start () {
        speed = Random.Range(min, max);
        distance = Random.Range(6f,10f);
        player = FindObjectOfType<TopDownPlayer>();
        health = FindObjectOfType<PlayerHealth>();
        line = gameObject.AddComponent<LineRenderer>();
        line.endWidth = line.startWidth = 0.1f;
        line.startColor = line.endColor = Color.red;
        line.positionCount = 2;
        line.material = mat;
    }

    private void Update()
    {
        WakeUp();
    }

    public void WakeUp()
    {

        if (health.isAlive)
        {
            line.SetPosition(0, transform.position);
            if (Vector2.Distance(transform.position, player.transform.position) < distance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                line.SetPosition(1, player.transform.position);
            }
            else
            {
                line.SetPosition(1, transform.position);
            }
        }
        else
        {
            line = null;
        }
    }
}
