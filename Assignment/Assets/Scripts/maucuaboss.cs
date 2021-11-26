using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maucuaboss : MonoBehaviour {

    public float maxHealth;
    private float currentHealth;
    public GameObject hieuung;
    public GameObject key;
    public AudioClip die;
    AudioSource audioSource;

    public Slider thanhmau;
	void Start () {
        audioSource = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        thanhmau.maxValue = maxHealth;
        thanhmau.value = maxHealth;
	}
	
	void Update () {
        
	}
    public void addDamge(float damage)
    {
        
        currentHealth -= damage;
        thanhmau.value = currentHealth;
        thanhmau.gameObject.SetActive(true);
        if (currentHealth <= 0)
        {
            key.SetActive(true);
            makeDead();
        }
    }
    void makeDead()
    {
        
        Instantiate(hieuung, transform.position, transform.rotation);
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
