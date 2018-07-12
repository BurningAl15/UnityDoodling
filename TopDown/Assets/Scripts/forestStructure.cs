using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forestStructure : MonoBehaviour {

    public int size;
    int rand;
    int x, y;
    public int mapWidth, mapHeight;
    public GameObject[] objects;
    public Color color;
    // Use this for initialization
    void Start () {
        Randomize();
        size = Random.Range(3, 6);
        mapWidth = Random.Range(5, 15);
        mapHeight = Random.Range(5, 15);
        for (int i = 0; i < size; i++)
        {
            var a = Instantiate(objects[rand], new Vector2(x, y), Quaternion.identity);

            for (int j = 0; j < a.GetComponentsInChildren<SpriteRenderer>().Length; j++)
            {
                a.GetComponentsInChildren<SpriteRenderer>()[j].color = color;
            }
            Randomize();
        }
    }

    void Randomize()
    {
        rand = Random.Range(0, objects.Length);
        x = Random.Range(-mapWidth, mapWidth);
        y = Random.Range(-mapHeight, mapHeight);
        color.r = Random.Range(0f, 1f);
        color.g = Random.Range(0f, 1f);
        color.b = Random.Range(0f, 1f);
        color.a = 255f;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
