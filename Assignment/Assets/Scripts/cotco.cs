﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cotco : MonoBehaviour {

    public GameObject cobala;

	void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cobala.SetActive(true);
        }
        
    }
}
