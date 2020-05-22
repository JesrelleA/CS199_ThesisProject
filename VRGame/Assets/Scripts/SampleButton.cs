using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SampleButton : MonoBehaviour
{
    public Button Buttonobj;
    public TextMeshProUGUI Name;

    private Player player;
    private ViewPlayerList playerList;

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


    }

}
