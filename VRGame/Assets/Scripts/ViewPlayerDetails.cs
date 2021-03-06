﻿using System.Collections;
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
    private int id;
    private string name;
    private int age;
    private string sex;
    private string remarks;
    
    public Text DisplayName;
    public Text DisplayAge;
    public Text DisplaySex;
    public Text DisplayRemarks;

    public Button EditDetailsBtn;
    public Button ViewRecordsBtn;
    public Button PlayBtn;
    public Button BackBtn;

    public GameObject Image; 
    public GameObject ViewPlayers;
    public GameObject PlayerDetails;
    public GameObject EditDetails;
    public GameObject ViewRecords;

    void Start()
    {
        GetPlayerDetails(); 
        Image.SetActive(true);
        DisplayPlayerDetails();

        EditDetailsBtn.onClick.AddListener(HandleEditDetailsBtnClick);
        ViewRecordsBtn.onClick.AddListener(HandleViewRecordsBtnClick);
        PlayBtn.onClick.AddListener(HandlePlayBtn);
        BackBtn.onClick.AddListener(HandleBackBtnClick);
    }

    void Update() {
        GetPlayerDetails();
        DisplayPlayerDetails();
    }

    private void GetPlayerDetails() {
        id = ViewPlayerList.session;

        //Get other data from database
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to database

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT Name, Age, Sex, Remarks FROM Players WHERE PlayerID = " + id;

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            name = reader.GetString(0);
            age = reader.GetInt32(1);
            string tempsex = reader.GetString(2);
            if (tempsex == "f") {
                sex = "female";
            } else {
                sex = "male";
            }
            remarks = reader.GetString(3);
        }

        reader.Close();
        reader = null;
    }

    private void DisplayPlayerDetails() {
        DisplayName.text = name;
        DisplayAge.text = Convert.ToString(age);
        DisplaySex.text = sex;
        DisplayRemarks.text = remarks;
    }

    private void HandleEditDetailsBtnClick() {
        Image.SetActive(false);
        PlayerDetails.SetActive(false);
        EditDetails.SetActive(true); 
    }

    private void HandleViewRecordsBtnClick() {
        PlayerDetails.SetActive(false);
        ViewRecords.SetActive(true);
    }

    private void HandlePlayBtn() {
        SceneManager.LoadScene(3);
    }

    private void HandleBackBtnClick() {
        SceneManager.LoadScene(2);
    }
}
