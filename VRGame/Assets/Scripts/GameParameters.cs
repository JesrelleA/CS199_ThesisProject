using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameParameters : MonoBehaviour
{
    public Button StartBtn;

    void Start() {
        StartBtn.onClick.AddListener(StartGame);
    }

    public void StartGame() {
        SceneManager.LoadScene(4);
    }

}
