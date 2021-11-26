using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour {

    public GameObject keyDoor;

	void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            keyDoor.SetActive(true);
            Destroy(gameObject);
        }
    }
}
