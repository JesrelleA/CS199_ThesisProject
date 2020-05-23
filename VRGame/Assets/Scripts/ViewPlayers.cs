using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.Linq;

public class ViewPlayers : MonoBehaviour
{

    public static int session;
    private int tempid;
    private int id;
    private string name;
    private int age;
    private string sex;
    private string remarks;
    
    public GameObject PlayersPrefab;
    //public Button ViewDetailsButton;
    //public Button ViewRecordsButton;
    //public Button EditDetailsButton;
    //public Button PlayButton;
    public Button TestButton;
    public TextMeshProUGUI DisplayName; 
    public TextMeshProUGUI DisplayAge;
    public TextMeshProUGUI DisplaySex;
    public TextMeshProUGUI DisplayRemarks;

    Dictionary<int, ArrayList> playerdictionary = new Dictionary<int, ArrayList>();

    void Start() {

        //TestButton.onClick.AddListener(() => ViewDetails());
        
        GetPlayers();

        int j = 0;
        for (int i=1; i<playerdictionary.Count+1; i++) { 
            DisplayName.text = Convert.ToString(playerdictionary[i][0]);
            id = playerdictionary.Keys.ElementAt(j);
            tempid = id;
            //Debug.Log(id);
            j++;
            TestButton.onClick.AddListener(() => ViewDetails());
            //ViewDetailsButton.onClick.AddListener(ViewDetails);
            //m_YourSecondButton.onClick.AddListener(delegate {TaskWithParameters("Hello"); });
            //ViewDetailsButton.onClick.AddListener(delegate {ViewDetails(); });
            //ViewDetailsButton.onClick.AddListener(() => ViewDetails());
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

    public void ViewDetails() {
        //Debug.Log(id);
        //Debug.Log(tempid);
        Debug.Log("inside view details");
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
