using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ong : MonoBehaviour {

    public GameObject quaivat2;

    void Start()
    {
        StartCoroutine(Attack());
    }

    void Update()
    {

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 5));
        Instantiate(quaivat2, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
}
