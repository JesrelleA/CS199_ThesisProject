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

public class ViewPlayerDetails : MonoBehaviour
{
    //private Player player;
    private string name;
    private int age;
    private string sex;
    private string remarks;
    
    public TextMeshProUGUI DisplayName;
    public TextMeshProUGUI DisplayAge;
    public TextMeshProUGUI DisplaySex;
    public TextMeshProUGUI DisplayRemarks;

    public Button EditDetailsBtn;
    public Button ViewRecordsBtn;
    public Button PlayBtn;
    public Button BackBtn;

    public GameObject ViewPlayers;
    public GameObject PlayerDetails;
    public GameObject ViewRecords;



    
    // Start is called before the first frame update
    void Start()
    {
        GetPlayerDetails(); 
        DisplayName.text = name;
        Debug.Log(name);
        DisplayAge.text = Convert.ToString(age);
        Debug.Log(age);
        DisplaySex.text = sex;
        Debug.Log(sex);
        DisplayRemarks.text = remarks;
        Debug.Log(remarks);

        ViewRecordsBtn.onClick.AddListener(HandleViewRecordsBtnClick);
        BackBtn.onClick.AddListener(HandleBackBtnClick);
    }

    private void GetPlayerDetails() {
        int id = ViewPlayerList.session;
        Debug.Log(id);

        //Get other data from database
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to database

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT Name, Age, Sex, Remarks FROM Players WHERE PlayerID = " + id;
        Debug.Log(sqlQuery);

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            name = reader.GetString(0);
            age = reader.GetInt32(1);
            string tempage = reader.GetString(2);
            if (tempage == "f") {
                sex = "female";
            } else {
                sex = "male";
            }
            remarks = reader.GetString(3);
        }

        reader.Close();
        reader = null;
    }

    private void HandleViewRecordsBtnClick() {
        PlayerDetails.SetActive(false);
        ViewRecords.SetActive(true);
    }

    private void HandleBackBtnClick() {
        Debug.Log("back button clicked");
        //PlayerDetails.SetActive(false);
        //ViewPlayers.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
