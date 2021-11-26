using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traitung : MonoBehaviour {

    public float Speed=1f;
    public Rigidbody2D myBody;
    private int somang;
    public float lifeTime = 1;
    private void Awake()
    {
        myBody.GetComponent<Rigidbody2D>();

        myBody.AddForce(new Vector2(0, 1) * Speed, ForceMode2D.Impulse);
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
