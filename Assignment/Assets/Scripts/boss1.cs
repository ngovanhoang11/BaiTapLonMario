using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss1 : MonoBehaviour
{

    private Transform boss;
    public GameObject PlayerDie;
    public Text mang;
    private int somang;
    public GameObject gameoverpanel;
    void Start()
    {
        boss = GameObject.Find("BOSS").transform;
    }

    void Update()
    {
        if (boss != null)
        {
            Vector3 temp = transform.position;
            temp.x = boss.position.x;
            transform.position = temp;
        }
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
