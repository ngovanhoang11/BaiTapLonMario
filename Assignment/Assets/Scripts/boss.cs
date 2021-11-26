using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour {

    public float enemySpeed;
    Rigidbody2D enemyRb;
    Animator enemyAnim;

    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 3f;
    float nextFlip = 0f;
    bool canFlip = true;

    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }

    void Start () {
		
	}
	
	void Update () {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(facingRight && collision.transform.position.x < transform.position.x)
            {
                flip();
            }else if (!facingRight && collision.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!facingRight)
            {
                enemyRb.AddForce(new Vector2(-1, 0) * enemySpeed);
            }
            else
            {
                enemyRb.AddForce(new Vector2(1, 0) * enemySpeed);
            }
            enemyAnim.SetBool("monster", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canFlip = true;
            enemyRb.velocity = new Vector2(0, 0);
            enemyAnim.SetBool("monster", false);
        }
    }
    void flip()
    {
        if (!canFlip)
            return;

        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
