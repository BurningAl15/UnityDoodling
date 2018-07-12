using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweetInstantiator : MonoBehaviour {

    public GameObject nnn;
    public GameObject mint;
    public int type;

    public float x, y;
    Vector2 newPos;
    Vector2 newPos2;
    public float delay;
    float startingDelay;
    public int xMin,xMax;
    public Transform p1, p2;

    Vector3 P1, P2;

	// Use this for initialization
	void Start () {
        startingDelay = delay;
        x = Random.Range(xMin, xMax);
        y = gameObject.transform.position.y;
        newPos = new Vector2(x, y);
        this.gameObject.transform.position = newPos;

        P1 = new Vector3(p1.transform.position.x, p1.transform.position.y, p1.transform.position.z);
        P2 = new Vector3(p2.transform.position.x, p2.transform.position.y, p2.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        delay -= Time.deltaTime;

        if(delay<=0)
        {
            x = Random.Range(xMin, xMax);
            y = gameObject.transform.position.y;
            newPos = new Vector2(x, y);
            newPos2 = new Vector2(x, y);
            this.gameObject.transform.position = newPos;

            P1 = new Vector3(p1.transform.position.x, p1.transform.position.y, p1.transform.position.z);
            P2 = new Vector3(p2.transform.position.x, p2.transform.position.y, p2.transform.position.z);

            Instantiate(mint,P1,Quaternion.identity);
            Instantiate(nnn, P2, Quaternion.identity);
            delay = startingDelay;

            
        }
	}


}
