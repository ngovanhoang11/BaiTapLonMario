using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip audioDie;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void RestartPlayer(GameObject player)
    {
        StartCoroutine(Restart(player));
        audioSource.PlayOneShot(audioDie);
    }
    private IEnumerator Restart(GameObject player)
    {
        yield return new WaitForSeconds(2);

        Vector3 pos = new Vector3();
        pos.x = player.transform.position.x - 1;
        pos.y = 0;
        pos.z = player.transform.position.z;

        GameObject.Destroy(player);
        player = GameObject.Instantiate(player);
        movePlayer move = player.GetComponent<movePlayer>();
        move.gameManager = gameObject;

        player.transform.position = pos;
        player.GetComponent<Collider2D>().enabled = true;
        player.GetComponent<movePlayer>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<AudioSource>().enabled = true;


        player.SetActive(true);
    }
}
