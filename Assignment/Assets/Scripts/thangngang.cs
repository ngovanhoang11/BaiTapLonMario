using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thangngang : MonoBehaviour {
    public float speed = 1f;

    private Rigidbody2D myBody;

    [SerializeField]
    private Transform startPos, endPos;

    private bool collision;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
        changeDerection();
    }

    void Move()
    {
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
    void changeDerection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("nendat"));

        Debug.DrawLine(startPos.position, endPos.position, Color.green);

        if (!collision)
        {
            Vector3 temp = transform.localScale;

            if (temp.x == 2.5f)
            {
                temp.x = -2.5f;
            }
            else
            {
                temp.x = 2.5f;
            }

            transform.localScale = temp;
        }
    }
}
