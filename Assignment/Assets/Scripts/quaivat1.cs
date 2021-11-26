using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class quaivat1 : MonoBehaviour {

    public float speed = 1f;

    private Rigidbody2D myBody;

    [SerializeField]
    private Transform startPos, endPos;

    public Text mang;
    private int somang;

    public GameObject PlayerDie;
    public GameObject gameoverpanel;
    public Button btnplayagain;

    private movePlayer move;

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
                       
            if (temp.x == 1.2f)
            {
                temp.x = -1.2f;
                Invoke("thayDoiViTriCuaEndpos1", 0.5f);                
            }
            else
            {
                temp.x = 1.2f;
                Invoke("thayDoiViTriCuaEndpos2", 0.5f);
            }

            transform.localScale = temp;
        }
    }

    void thayDoiViTriCuaEndpos1()
    {
        if (startPos.name == "quaivat1-1")
        {
            Vector2 temp1 = transform.position;
            temp1.x = -3f;
            temp1.y = -3.95f;
            endPos.position = temp1;
        }
        if (startPos.name == "quaivat1-2")
        {
            Vector2 temp2 = transform.position;
            temp2.x = -2.2f;
            temp2.y = -3.85f;
            endPos.position = temp2;
        }
        
    }
    void thayDoiViTriCuaEndpos2()
    {
        if (startPos.name == "quaivat1-1")
        {
            Vector2 temp1 = transform.position;
            temp1.x = -3f;
            temp1.y = -3.95f;
            endPos.position = temp1;
        }
        if (startPos.name == "quaivat1-2")
        {
            Vector2 temp2 = transform.position;
            temp2.x = -1f;
            temp2.y = -3.95f;
            endPos.position = temp2;
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
            Invoke("loadlaigameneunhanvatdie", 1);// chờ 1 giây sau đó load lại game

            collision.gameObject.GetComponent<movePlayer>().RestartPlayer();
            
        }
    }

    void loadlaigameneunhanvatdie()
    {
        if (Convert.ToInt32(mang.text) > 0)
        {
            
            //Scene scene = SceneManager.GetActiveScene();// lấy ra tên của Scene
            //Application.LoadLevel(scene.name);

            somang = Convert.ToInt32(mang.text) - 1;
            mang.text = somang.ToString();
        }
        if (Convert.ToInt32(mang.text) <= 0)
        {
            Time.timeScale = 0f;
            gameoverpanel.SetActive(true);
            btnplayagain.onClick.RemoveAllListeners();
            btnplayagain.onClick.AddListener(() => playAgain());
        }

    }

    public void playAgain()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();// lấy ra tên của Scene
        Application.LoadLevel(scene.name);
        gameoverpanel.SetActive(false);
    }
}
