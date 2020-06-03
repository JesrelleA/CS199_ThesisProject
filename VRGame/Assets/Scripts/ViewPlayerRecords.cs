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


public class ViewPlayerRecords : MonoBehaviour
{
    private string name;
    private string records;

    public Button Backbtn;
    public Text DisplayName;
    public Text DisplayRecords;

    public GameObject PlayerDetails;
    public GameObject ViewRecords;
    
    // Start is called before the first frame update
    void Start()
    {
        GetRecords();
        DisplayName.text = name;
        DisplayRecords.text = records;

        Backbtn.onClick.AddListener(HandleBackBtnClick);
    }

    private void GetRecords() {
        int id = ViewPlayerList.session;
        Debug.Log(id);

        //Get other data from database
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to database

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT Players.Name, Records.Record FROM Players INNER JOIN Records ON Players.PlayerID = " + id + " and Records.PlayerID = " + id;
        Debug.Log(sqlQuery);

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            name = reader.GetString(0);
            records = reader.GetString(1);
        }

        reader.Close();
        reader = null;
    }

    private void HandleBackBtnClick() {
        ViewRecords.SetActive(false);
        PlayerDetails.SetActive(true);
    }
}
