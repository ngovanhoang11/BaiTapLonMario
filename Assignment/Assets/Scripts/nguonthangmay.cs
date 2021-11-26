using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nguonthangmay : MonoBehaviour {
    public GameObject bacthang;

    void Start()
    {
        StartCoroutine(Attack());
    }

    void Update()
    {

    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(bacthang, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }
}
