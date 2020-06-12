using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameParameters : MonoBehaviour
{
    public Button StartBtn;
    public Button HomeBtn;

    void Start() {
        StartBtn.onClick.AddListener(StartGame);
        HomeBtn.onClick.AddListener(Home);
    }

    private void StartGame() {
        SceneManager.LoadScene(4);
    }

    private void Home() {
        SceneManager.LoadScene(0);
    }

}
