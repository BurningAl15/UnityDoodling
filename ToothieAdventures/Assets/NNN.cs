using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NNN : MonoBehaviour {

    SpriteRenderer sprite;
    Color color;
    public float r, g, b, a;
    Rigidbody2D rgb;
    public float speed;
    public int xDir;
    public int yDir;

    public GameObject SweetParticles;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        r = Random.Range(0, 1f);
        g = Random.Range(0, 1f);
        b = Random.Range(0, 1f);
        a = 1f;
        color = new Color(r, g, b, a);
        sprite.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        NnN();
    }

    void NnN()
    {
        Vector2 move=new Vector2(xDir*speed,yDir*speed);
        rgb.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            PlayerBehaviour.isAlive = false;
        }
        if(collision.tag.Equals("Ground") || collision.tag.Equals("Brokable") || collision.tag.Equals("Button") || collision.tag.Equals("Obstacle"))
        {
            Instantiate(SweetParticles, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
