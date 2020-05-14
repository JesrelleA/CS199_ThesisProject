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

    //Sample data 
    ArrayList list1 = new ArrayList();
    ArrayList list2 = new ArrayList();
    ArrayList list3 = new ArrayList();
    Dictionary<int, ArrayList> playerdictionary = new Dictionary<int, ArrayList>();
    
    public TextMeshProUGUI DisplayName; 
    public TextMeshProUGUI DisplayAge;
    public TextMeshProUGUI DisplaySex;
    public TextMeshProUGUI DisplayRemarks;
    
    private int id;
    private string name = "Helena";
    private int age = 8;
    private string sex = "female";
    private string remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

    public GameObject PlayersPrefab;

    void Start() {
        
        GetPlayers();
        Debug.Log(playerdictionary.Count);

        for (int i=1; i<playerdictionary.Count+1; i++) {
            GameObject NewPlayers = Instantiate<GameObject>(PlayersPrefab, transform);
            DisplayName.text = Convert.ToString(playerdictionary[i][0]);
        }

    
        //DisplayNameText();
        //DisplayAgeText();
        //DisplaySexText();
        //DisplayRemarksText();
    }

    public void GetPlayers() {
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        Debug.Log("new sqlite conn");
        dbconn.Open(); //Open connection to database
        Debug.Log("db open");

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT * FROM Players";

        dbcmd.CommandText = sqlQuery;
        Debug.Log(sqlQuery);
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


            //Debug.Log(name);
        }

        reader.Close();
        reader = null;

    }

    public void Home() {
        SceneManager.LoadScene(0);
    }

    public void DisplayNameText() {
        DisplayName.text = name;
        Debug.Log("please :("); 
    }

    public void DisplayAgeText() {
        DisplayAge.text = age.ToString();
    }

    public void DisplaySexText() {
        DisplaySex.text = sex;
    }

    public void DisplayRemarksText() {
        DisplayRemarks.text = remarks;
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
