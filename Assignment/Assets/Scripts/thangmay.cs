using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thangmay : MonoBehaviour {

    public float Speed;
    public Rigidbody2D myBody;
    public float lifeTime;
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
