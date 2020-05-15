using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class ViewPlayers : MonoBehaviour
{

    Dictionary<int, ArrayList> playerdictionary = new Dictionary<int, ArrayList>();
    

    public TextMeshProUGUI DisplayName; 
    public TextMeshProUGUI DisplayAge;
    public TextMeshProUGUI DisplaySex;
    public TextMeshProUGUI DisplayRemarks;
    public TextMeshProUGUI Test;
    
    private int id;
    private string name;
    private int age;
    private string sex;
    private string remarks;

    public GameObject PlayersPrefab;

    void Start() {
        
        GetPlayers();

        for (int i=1; i<playerdictionary.Count+1; i++) { 
            DisplayName.text = Convert.ToString(playerdictionary[i][0]);
            GameObject NewPlayers = Instantiate<GameObject>(PlayersPrefab, transform);
            
        }
    }

    public void GetPlayers() {
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to database

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT * FROM Players";

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            int tempid = reader.GetInt32(0);
            string tempname = reader.GetString(1);
            int tempage = reader.GetInt32(2);
            string tempsex = reader.GetString(3);
            string tempremarks = reader.GetString(4);

            ArrayList details = new ArrayList();
            details.Add(tempname);
            details.Add(tempage);
            details.Add(tempsex);
            details.Add(tempremarks);

            playerdictionary.Add(tempid, details);
        }

        reader.Close();
        reader = null;

    }

    public void Home() {
        SceneManager.LoadScene(0);
    }

    /*


    public void DisplayAgeText() {
        DisplayAge.text = age.ToString();
    }

    public void DisplaySexText() {
        DisplaySex.text = sex;
    }

    public void DisplayRemarksText() {
        DisplayRemarks.text = remarks;
    }
    */
}
