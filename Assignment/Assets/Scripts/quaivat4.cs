using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quaivat4 : MonoBehaviour {

    public float speed = 1f;

    private Rigidbody2D myBody;

    [SerializeField]
    private Transform startPos, endPos;

    public Text mang;
    private int somang;

    public GameObject PlayerDie;
    public GameObject gameoverpanel;
    public Button btnplayagain;

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
        myBody.velocity = new Vector2(transform.localScale.x, 0) * -speed;
    }
    void changeDerection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("brick"));

        Debug.DrawLine(startPos.position, endPos.position, Color.green);

        if (!collision)
        {
            Vector3 temp = transform.localScale;

            if (temp.x == 0.8f)
            {
                temp.x = -0.8f;
            }
            else
            {
                temp.x = 0.8f;
            }

            transform.localScale = temp;
        }
    }


    /// <summary>
    /// khi nhân vật chạm vào thì nhân vật sẽ biến mất => chết
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(PlayerDie, transform.position, transform.rotation);
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
            Invoke("loadlaigameneunhanvatdie", 0);// chờ 1 giây sau đó load lại game

            collision.gameObject.GetComponent<movePlayer>().RestartPlayer();

        }
    }

    void loadlaigameneunhanvatdie()
    {
        
        if (Convert.ToInt32(mang.text) > 0)
        {
            
            somang = Convert.ToInt32(mang.text) - 1;
            mang.text = somang.ToString();
        }
        if (Convert.ToInt32(mang.text) <= 0)
        {
            Time.timeScale = 0f;
            gameoverpanel.SetActive(true);
        }

    }

}
