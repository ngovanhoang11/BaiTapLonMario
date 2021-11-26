using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class viendan : MonoBehaviour {

    public float Speed;
    public GameObject nameofsung;
    public Rigidbody2D myBody;
    public float lifeTime;
    private void Awake()
    {
        myBody.GetComponent<Rigidbody2D>();

        if(nameofsung.name == "sung1")
        {
            myBody.AddForce(new Vector2(1, 0) * Speed, ForceMode2D.Impulse);
        }
        if(nameofsung.name == "sung2")
        {
            myBody.AddForce(new Vector2(-1, 0) * Speed, ForceMode2D.Impulse);
        }
        
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
