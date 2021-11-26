using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {


    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("openthedoor", true);
            quaman();
        }
        else
        {
            anim.SetBool("openthedoor", false);
        }
    }
    void quaman()
    {
        Invoke("quaman1", 0.5f);
        
    }
    void quaman1()
    {
        Application.LoadLevel("GamePlay2");
    }
}
