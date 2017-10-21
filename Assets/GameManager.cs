using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static int score = 0;
    public GameObject ball;
    public GameObject[] blocks;
    public int width;
    public int height;
    GameObject cloneBall;
    void level1()
    {
        //spawn the level
        for(int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject cloneBlock = Instantiate(blocks[0],GameObject.Find("Bricks").transform);
                cloneBlock.transform.position = new Vector3(-width/2*(.75f)+(i*.75f),height/2-(j*.5f)+1,0);
            }
        }
    }
    void spawnBall()
    {
        cloneBall = Instantiate(ball, GameObject.Find("PlayerPaddle").transform);
    }
	// Use this for initialization
	void Start () {
        level1();
        spawnBall();
	}
    bool start = true;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(start);
            start = false;
        }
        if (!start)
        {
            //ball is stuck to paddle else un parent and activate ball ai to move forward
            cloneBall.transform.parent = null;
            cloneBall.GetComponent<BallScript>().active = true;
        }
	}
}
