using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    [Header("Map Randomizer")]
    public GameObject[] objects;
    public int size;//Quantity of elements
    public int mapWidth, mapHeight;
    int x, y;
    int rand;
    Vector3 scale;
    public Color color;

    public List<GameObject> trees;
    public List<GameObject> enemies;

    private void Awake()
    {
        Randomize();
        for (int i = 0; i < size; i++)
        {
            //scale = new Vector3(Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f), Random.Range(0.2f, 0.5f));
            scale = new Vector3(0.3f, 0.3f, 0.3f);
            var a = Instantiate(objects[rand], new Vector2(x, y), Quaternion.identity);
            if (a.tag.Equals("Obstacles"))
                trees.Add(a);

            if (a.GetComponent<SpriteRenderer>() != null)
            {
                if (a.tag.Equals("Enemy"))
                {
                    enemies.Add(a);
                    a.GetComponent<SpriteRenderer>().color = Color.red;
                }
                else
                {
                    a.GetComponent<SpriteRenderer>().color = color;
                    a.transform.localScale = scale;
                }
            }
            else
            {
                for (int j = 0; j < a.GetComponentsInChildren<SpriteRenderer>().Length; j++)
                {
                    a.GetComponentsInChildren<SpriteRenderer>()[j].color = color;
                }
            }

            Randomize();
        }
    
    }
	
    void Randomize()
    {
        rand = Random.Range(0, objects.Length);
        x = Random.Range(-mapWidth, mapWidth);
        y = Random.Range(-mapHeight, mapHeight);
        //Check
        color.r = Random.Range(0f, 1f);
        color.g = 0.5f;
        color.b = Random.Range(0f, 1f);
        color.a = 255f;
    }
    
}
