using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

/*
Scene names and index
    MainMenu_Scene      0
    CreatePlayer_Scene  1
    ViewPlayer_Scene    2
    OpeningGame_Scene   3
    Game_Scene          4
*/

public class MainMenu : MonoBehaviour
{
    public void ViewPlayers() {
        SceneManager.LoadScene(2);
    }

    public void CreatePlayer() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Debug.Log("QUIT");
        Application.Quit();
    }


    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
