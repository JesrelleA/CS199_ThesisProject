using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MainGame : MonoBehaviour
{
    public Button HomeBtn;

    void Start() {
        HomeBtn.onClick.AddListener(Home);
    }

    private void Home() {
        SceneManager.LoadScene(0);
    }

}
