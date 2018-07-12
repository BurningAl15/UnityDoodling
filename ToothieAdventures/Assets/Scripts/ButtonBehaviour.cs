using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour {

    public int type;
    public GameObject obstacle;
    public GameObject[] obstacles;

	// Use this for initialization
	void Start () {
        switch(type)
        {
            default:
            case 0:
                for (int i = 0; i < obstacles.Length; i++)
                {
                    obstacles[i] = null;
                }
                break;
            case 1:
                obstacle = null;
                break;
        }
       
        //if (obstacle != null)
        //{
        //    obstacle.SetActive(false);
        //}

       
    }
	
	// Update is called once per frame
	void Update () {
		//switch(type)
  //      {
  //          default:
  //          case 1:
  //              DoughnutOn();
  //              break;
  //      }
	}

    void DoughnutOn()
    {
        if(obstacle!=null)
        { 
            obstacle.gameObject.GetComponent<CandyInstantiator>().active = true;
        }
    }

    void Sweets()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i] != null)
            {
                obstacles[i].gameObject.GetComponent<CandyInstantiator>().active = true;
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            switch(type)
            {
                default:
                case 0:
                    DoughnutOn();
                    break;
                case 1:
                    Sweets();
                    break;
            }

        }
    }

}
