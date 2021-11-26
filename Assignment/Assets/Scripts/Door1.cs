using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1 : MonoBehaviour {

    public GameObject key1;
    public GameObject comingsoon;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start () {
		
	}
	
	void Update () {
        if (key1 == null)
        {
            Invoke("wait", 1);
        }
    }
    void wait()
    {
        anim.SetBool("openthedoor2", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            comingsoon.SetActive(true);
        }
    }
}
