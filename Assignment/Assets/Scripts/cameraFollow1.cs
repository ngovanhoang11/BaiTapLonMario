using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow1 : MonoBehaviour {

    private Transform player;
    //public GameObject Player;
    public float minX, maxX;

    void Start () {
        player = GameObject.Find("player").transform;
    }
	
	void Update () {
        if(player == null)
        {
            player = GameObject.Find("player(Clone)").transform;
        }
        

        if (player != null)
        {
            Vector3 temp = transform.position;
            temp.x = player.position.x;

            if(temp.x < minX)
            {
                temp.x = minX;
            }
            
            if(temp.x > maxX)
            {
                temp.x = maxX;
            }

            transform.position = temp;
        }
       
    }
}
