using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    public bool active = false;
    public float speed;
    bool upDown = false;
    float horizontalMovement = 0;
    void OnCollisionEnter2D(Collision2D col)
    {
        GetComponent<AudioSource>().Play();
        if (col.transform.tag == "brick")
        {
            //generate a random angle to move in then rotate the ball
            col.gameObject.transform.parent.GetComponent<Brick>().hp--;
            horizontalMovement = Random.Range(10, 170);
        }
        if (col.transform.tag != "wall")
        {
            if (upDown)
            {
                upDown = false;
            }
            else
            {
                upDown = true;
            }
        }else
        {
            horizontalMovement = -horizontalMovement;
        }


    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            if (upDown)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(horizontalMovement/100, 1, 0).normalized * speed;
            }else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector3(horizontalMovement/100, -1, 0).normalized * speed;
            }

        }
	}
}
