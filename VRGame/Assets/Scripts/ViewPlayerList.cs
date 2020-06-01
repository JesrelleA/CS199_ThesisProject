using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using TMPro;

using Mono.Data.Sqlite;
using System.Data;

[System.Serializable]
public class Player {
    public int id;
    public string name;
}

public class ViewPlayerList : MonoBehaviour
{
    public static int session;
    public List<Player> playerlist;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    public TextMeshProUGUI SceneTitle;

    // Start is called before the first frame update
    void Start() {
        session = 0;
        SceneTitle.text = "Player List";
        AddPlayer();
        AddButtons();
    }

    private void AddButtons() {
        SceneTitle.text = "Player List";
        for (int i = 0; i < playerlist.Count; i++) {
            Player player = playerlist[i];
            GameObject newButton = buttonObjectPool.GetObject ();
            newButton.transform.SetParent(contentPanel); //not sure if this is necessary 

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(player, this);
        }
    }

    private void AddPlayer() {
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to database

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT PlayerID, Name FROM Players";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            Player addthisplayer = new Player();
            addthisplayer.id = reader.GetInt32(0);
            addthisplayer.name = reader.GetString(1);
            playerlist.Add(addthisplayer);
        } 

        reader.Close();
        reader = null;
    }

    public void Home() {
        SceneManager.LoadScene(0);
    }
}
