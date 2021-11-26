using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _modau : MonoBehaviour {

    public GameObject hopePanel;
    public Button man1;
    public Button man2;
    public Button man3;
    public Button man4;
    public Button man5;
    public Button playgame;
    public GameObject panelComingSoon3;
    public GameObject panelComingSoon4;
    public GameObject panelComingSoon5;

    void Start () {
        Invoke("showHopPanel", 2);
	}
	
	void Update () {
        man1.onClick.RemoveAllListeners();
        man1.onClick.AddListener(() => loadman1());

        man2.onClick.RemoveAllListeners();
        man2.onClick.AddListener(() => loadman2());

        man3.onClick.RemoveAllListeners();
        man3.onClick.AddListener(() => loadman3());

        man4.onClick.RemoveAllListeners();
        man4.onClick.AddListener(() => loadman4());

        man5.onClick.RemoveAllListeners();
        man5.onClick.AddListener(() => loadman5());

        playgame.onClick.RemoveAllListeners();
        playgame.onClick.AddListener(() => loadman1());
    }
    void showHopPanel()
    {
        hopePanel.SetActive(true);
    }

    void loadman1()
    {
        Application.LoadLevel("GamePlay1");
    }
    void loadman2()
    {
        Application.LoadLevel("GamePlay2");
    }
    void loadman3()
    {
        panelComingSoon3.SetActive(true);
    }
    void loadman4()
    {
        panelComingSoon4.SetActive(true);
    }
    void loadman5()
    {
        panelComingSoon5.SetActive(true);
    }
}
