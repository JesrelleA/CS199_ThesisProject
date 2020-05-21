using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;

[System.Serializable]
public class Player {
    public string name;
}

public class ViewPlayerList : MonoBehaviour
{
    public List<Player> playerlist;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    // Start is called before the first frame update
    void Start() {
        RefreshDisplay();
    }

    public void RefreshDisplay() {
        AddButtons();
    }

    private void AddButtons() {
        for (int i = 0; i < playerlist.Count; i++) {
            Player player = playerlist[i];
            GameObject newButton = buttonObjectPool.GetObject ();
            newButton.transform.SetParent(contentPanel); //not sure if this is necessary 

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(player, this);
        }
    }
}
