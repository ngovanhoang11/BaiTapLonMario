using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class movePlayer : MonoBehaviour {

    public float maxSpees;
    public float jumHeight;
    public Text coin;
    public Text traitung;
    public Text mang;
    public Text time;
    public GameObject gameoverpanel;
    public GameObject gameManager;
    public GameObject player;
    public GameObject PlayerDie;
    public Transform muisung;// vị trí viêm đạn sẽ được bắn ra
    public GameObject viendan;
    public GameObject khoi;
    public AudioClip audioCoin;
    public AudioClip audioDan;
    public AudioClip audioQuaTung;
    public GameObject huongdan;
    AudioSource audioSource;
    //[SerializeField] // khi khai báo private mà muốn truy xuất như public thì thêm [SerializeField]
    private Rigidbody2D myBody;
    private Animator anim;
    private bool grounded;//nếu nhân vật đang đứng trên nền đất thì có thể nhảy
    private int diemcoin;
    private int diemtraitung;
    private int somang;
    private float thoigian;
    private int thoigianInt;
    private bool facingRight;
    private float fireRate = 0.5f;
    private float nextFire = 0;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    void Start() {
        diemcoin = 0;
        diemtraitung = 0;
        thoigian = 100;
        time.text = thoigian.ToString();

        Vector3 theScale = transform.localScale;
        if (theScale.x == 0.25)
        {
            facingRight = true;
        }
        else
        {
            facingRight = false;
        }
    }

    void Update() {
        Thoigian();
        playerDead();
    }
    private void FixedUpdate()
    {
        PlayerMoveKeyBoard();
        playerDead();
        if (Input.GetAxisRaw("Fire1") > 0) // nếu như nhấn chuột trái thì...
        {
            if (Convert.ToInt32(traitung.text) > 0)
            {
                chucnangban();
            }
            
        }

    }
    void chucnangban()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; //sau 0.5 giây mới được bắn lượt tiếp theo
            if (facingRight)
            {
                Instantiate(viendan, muisung.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                diemtraitung = Convert.ToInt32(traitung.text) - 1;
                traitung.text = diemtraitung.ToString();
                audioSource.PlayOneShot(audioDan);
            }
            //else if (!facingRight)
            //{
            //    Instantiate(viendan, muisung.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            //    Instantiate(khoi, muisung.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            //}
        }
    }
    void PlayerMoveKeyBoard()
    {
        float move = Input.GetAxis("Horizontal");
        myBody.velocity = new Vector2(move * maxSpees, myBody.velocity.y);

        anim.SetFloat("playerRun", Mathf.Abs(move));

        if (gameObject.name == "player2" || gameObject.name == "player2(Clone)" || gameObject.name == "player2(Clone)(Clone)" || gameObject.name == "player2(Clone)(Clone)(Clone)")
        {
            if (move > 0 && !facingRight)
            {
                flip();
            }
            else if (move < 0 && facingRight)
            {
                flip();
            }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (grounded)
                {
                    grounded = false;
                    myBody.velocity = new Vector2(myBody.velocity.x, jumHeight);
                }
            }
        }
        else
        {
            if (move > 0 && facingRight)
            {
                flip();
            }
            else if (move < 0 && !facingRight)
            {
                flip();
            }
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (grounded)
                {
                    grounded = false;
                    myBody.velocity = new Vector2(myBody.velocity.x, jumHeight);
                }
            }
        }
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "matdat" || collision.gameObject.tag == "cucdat" || collision.gameObject.tag == "ong")
        {
            grounded = true;
        }
        if(collision.gameObject.tag == "quaivat2")
        {
            gameObject.SetActive(false);
            Instantiate(PlayerDie, transform.position, transform.rotation);
            RestartPlayer();
            loadlaigameneunhanvatdie();
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "danlua")
        {
            gameObject.SetActive(false);
            Instantiate(PlayerDie, transform.position, transform.rotation);
            RestartPlayer();
            loadlaigameneunhanvatdie();
            Destroy(collision.gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            collision.gameObject.SetActive(false);
            diemcoin = diemcoin + 1;
            coin.text = diemcoin.ToString();

            audioSource.PlayOneShot(audioCoin);
        }
        if (collision.gameObject.CompareTag("quathong"))
        {
            collision.gameObject.SetActive(false);
            diemtraitung = diemtraitung + 1;
            traitung.text = diemtraitung.ToString();

            audioSource.PlayOneShot(audioQuaTung);
        }
        if (collision.gameObject.CompareTag("huongdan"))
        {
            collision.gameObject.SetActive(false);
            huongdan.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void RestartPlayer()
    {
        gameManager.GetComponent<GameManager>().RestartPlayer(player);
    }
   
    public void playerDead()
    {
        if(transform.position.y < -5.23)
        {
            if (Convert.ToInt32(mang.text) > 0)
            {
                //Scene scene = SceneManager.GetActiveScene();// lấy ra tên của Scene
                //Application.LoadLevel(scene.name);

                gameManager.GetComponent<GameManager>().RestartPlayer(player);


                somang = Convert.ToInt32(mang.text) - 1;
                mang.text = somang.ToString();
            }
            if(Convert.ToInt32(mang.text) <= 0)
            {
                Time.timeScale = 0f;
                gameoverpanel.SetActive(true);
            }
            
        }
    }
    
    void Thoigian()
    {
        thoigian = thoigian - Time.deltaTime;//thời gian giảm dần
        thoigianInt = (int)thoigian; // chuyển kiểu float về int (lấy phần nguyên)
        time.text = thoigianInt.ToString();// set cho Text trong unity

        thoigian = Mathf.Clamp(thoigian, 0, Mathf.Infinity);// đặt gới hạn về 0

        if (Convert.ToInt32(time.text) == 0)
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
               
            }
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
