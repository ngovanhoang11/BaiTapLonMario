using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hieuungnoviendan : MonoBehaviour {

    danquantung Danquatung;
    maucuaboss mauboss;
    public GameObject hieuungviendan;
    public float satthuong;
    AudioSource audioSource;
    public AudioClip audioDie;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        Danquatung = GetComponentInParent<danquantung>();
        mauboss = GetComponent<maucuaboss>();
    }
    void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "shotable")
        {
            Danquatung.removeForce();
            Instantiate(hieuungviendan, transform.position, transform.rotation);
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            if(collision.gameObject.layer == LayerMask.NameToLayer("boss"))
            {
                maucuaboss mau = collision.gameObject.GetComponent<maucuaboss>();
                mau.addDamge(satthuong);
                audioSource.PlayOneShot(audioDie);
            }

        }
        

    }
}
