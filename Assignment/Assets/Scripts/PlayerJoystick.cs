using UnityEngine;
using System.Collections;

public class PlayerJoystick : MonoBehaviour
{

    public float speed = 8f, maxVelocity = 4f;
    public float jumHeight = 20f;
    private Rigidbody2D myBody;
    private Animator anim;
    private bool grounded;
    private bool moveLeft, moveRight, jump;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveLeft)
        {
            MoveLeft();
        }

        if (moveRight)
        {
            MoveRight();
        }
        if (jump)
        {
            Jump();
        }
    }

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void setJump(bool jump)
    {
        this.jump = jump;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetFloat("playerRun", 0);

    }
    public void StopJump()
    {
        grounded = false;
        myBody.velocity = new Vector2(myBody.velocity.x, 0);
    }

    void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
            forceX = -speed;

        Vector3 temp = transform.localScale;
        temp.x = -0.3f;
        transform.localScale = temp;

        float move = Random.Range(0.00000001f, 1);

        anim.SetFloat("playerRun", Mathf.Abs(move));

        myBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        if (vel < maxVelocity)
            forceX = speed;

        Vector3 temp = transform.localScale;
        temp.x = 0.3f;
        transform.localScale = temp;

        float move = Random.Range(0.00000001f, 1);

        anim.SetFloat("playerRun", Mathf.Abs(move));

        myBody.AddForce(new Vector2(forceX, 0));
    }

    void Jump()
    {
        if (grounded)
        {
            grounded = false;
            myBody.velocity = new Vector2(myBody.velocity.x, jumHeight);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "matdat" || collision.gameObject.tag == "cucdat" || collision.gameObject.tag == "ong")
        {
            grounded = true;
        }

    }
}
