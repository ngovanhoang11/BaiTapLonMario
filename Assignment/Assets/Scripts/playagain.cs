using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playagain : MonoBehaviour {

    public void playAgain()
    {
        Scene scene = SceneManager.GetActiveScene();// lấy ra tên của Scene
        Application.LoadLevel(scene.name);
    }
}
