using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SampleButton : MonoBehaviour
{
    private Player player;
    private ViewPlayerList playerList;
    
    public Button Buttonobj;
    public TextMeshProUGUI Name;
    //public TextMeshProUGUI SceneTitle;
    public GameObject PlayerDetails;
    public GameObject ViewPlayers;
    

    // Start is called before the first frame update
    void Start() {
        Buttonobj.onClick.AddListener(HandleClick);
    }

    public void Setup(Player currentPlayer, ViewPlayerList currentPlayerList) {
        player = currentPlayer;
        Name.text = player.name;

        playerList = currentPlayerList;
    }

    public void HandleClick() { //must go to a view where player details, edit details button, view records button, play button and back button is displayed
        ViewPlayerList.session = player.id;
        Debug.Log(ViewPlayerList.session);
        //Debug.Log(player.id);

        PlayerDetails.SetActive(true);
        ViewPlayers.SetActive(false);
        //SceneTitle.text = player.name;
    }

}
