using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    public Color start;
    public Color damage;
    public int hp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (hp == 2)
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = start;
        }else if (hp == 1)
        {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = damage;

        }
        if (hp <= 0)
        {
            GameManager.score += 200;
            this.gameObject.SetActive(false);
            //gameobject turns itself off
            //dont destroy because its more expensive
        }
	}
}
