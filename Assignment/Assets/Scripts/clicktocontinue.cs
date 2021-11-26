using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicktocontinue : MonoBehaviour {
    public GameObject panelComingSoon3;
    public GameObject panelComingSoon4;
    public GameObject panelComingSoon5;
    
    public void Continue()
    {
        Time.timeScale = 1f;
        panelComingSoon3.SetActive(false);
        panelComingSoon4.SetActive(false);
        panelComingSoon5.SetActive(false);
    }
    public void gotomenu()
    {
        Application.LoadLevel("manhinhbatdau");
    }
}
