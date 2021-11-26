using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danquantung : MonoBehaviour {

    public float bulletSpees;
    public float lifeTime;
    private Rigidbody2D myBody;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z > 0)
        {
            myBody.AddForce(new Vector2(-1, 0) * bulletSpees, ForceMode2D.Impulse);
        }
        else
        {
            myBody.AddForce(new Vector2(1, 0) * bulletSpees, ForceMode2D.Impulse);
        }
        
    }

    void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	void Update () {
		
	}
    public void removeForce()
    {
        myBody.velocity = new Vector2(0, 0);
    }
}
