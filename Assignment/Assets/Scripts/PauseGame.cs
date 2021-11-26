using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {
    [SerializeField]
    private GameObject pausePanel;

    public Button btnThoatGame;
    public Button btnResume;


    /// <summary>
    /// sử dụng Toggle button... Toggle trả về giá trị True hoặc false khi được nhấn.
    /// </summary>
    /// <param name="value"></param>
    public void pauseGame()
    {
        
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            btnResume.onClick.AddListener(() => resumeGame());
            btnThoatGame.onClick.AddListener(() => thoatGame());
        
    }
    private void thoatGame()
    {
        Application.Quit();
    }
    private void resumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

}
