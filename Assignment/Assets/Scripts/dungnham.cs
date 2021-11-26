using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class dungnham : MonoBehaviour {

    public GameObject player;
    public GameObject gameManager;
    public GameObject PlayerDie;
    public GameObject gameoverpanel;
    public Button btnplayagain;
    public Text mang;
    private int somang;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

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
