using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class CreateNewPlayer : MonoBehaviour
{
    private string firstname;
    private string lastname;
    private string name;
    private int age;
    private string sex;
    private string remarks;

    public Text DisplayValFN;
    public Text DisplayValLN;
    public Text DisplayValA;
    public Text DisplayValS;
    public Text DisplayValR;
    
    public GameObject AfterCreate;
    public GameObject Inputs;
    public GameObject SceneTitle;
    public Text DisplayName;
    public Text DisplayAge;
    public Text DisplaySex;
    public Text DisplayRemarks;
    
    public void CreatePlayer() {
        
        //For validation/Check if input is empty
        bool isfirstname = true;
        bool islastname = true;
        bool isage = true;
        bool issex = true;
        bool isremarks = true;

        //Get values from input fields
        //Name
        firstname = GameObject.Find ("FirstNameInput").GetComponent<InputField>().text;
        if (firstname == "") {
            isfirstname = false;
            DisplayValFN.text = "Please enter a first name."; //Display validation text for empty first name
        } else {
            DisplayValFN.text = "";
        }
        Debug.Log(firstname);
        lastname = GameObject.Find ("LastNameInput").GetComponent<InputField>().text;
        if (lastname == "") {
            islastname = false;
            DisplayValLN.text = "Please enter a last name."; //Display validation text for empty last name
        } else {
            DisplayValLN.text = "";
        }
        name = firstname + " " + lastname;

        //Age
        string agetemp = GameObject.Find ("AgeInput").GetComponent<InputField>().text;
        if (agetemp == "") {
            isage = false;
            DisplayValA.text = "Please enter an age."; //Display validation text for empty age
        } else {
            age = Convert.ToInt32(agetemp);
            DisplayValA.text = "";
        }
    
        //Sex
        var isfemale = GameObject.Find ("Female");
        var ismale = GameObject.Find ("Male");
        if (isfemale.GetComponent<Toggle>().isOn == true) {
            sex = "f";
        }
        if (ismale.GetComponent<Toggle>().isOn == true) {
            sex = "m";
        }
        if ((isfemale.GetComponent<Toggle>().isOn || ismale.GetComponent<Toggle>().isOn) == false) {
            issex = false;
            DisplayValS.text = "Please choose a sex."; //Display validatio
        } else {
            DisplayValS.text = "";
        }

        //Remarks
        remarks = GameObject.Find ("RemarksInput").GetComponent<InputField>().text;
        if (remarks == "") {
            isremarks = false;
            DisplayValR.text = "Please enter a remark."; //Dispklay validation text for empty remarks
        } else {
            DisplayValR.text = "";
        }

        if (isfirstname && islastname && isage && issex && isremarks) {
            //Connect to DB
            string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

            Debug.Log(conn);
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to database

            IDbCommand dbcmd = dbconn.CreateCommand();

            //Insert to Players
            string sqlQuery = "INSERT INTO Players(Name, Age, Sex, Remarks) VALUES (\"" + name + "\", " + age + ", \"" + sex + "\", \"" + remarks + "\");"; //"INSERT INTO Players(Name, Age, Sex, Remarks) VALUES(\"hello2\", 6, \"f\", \"WORKED YAAAY\");"; //"SELECT * FROM Players;"; //"SELECT Name, Age, Sex, Remarks FROM Players";

            dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();

            reader.Close();
            reader = null;

            //Insert to Records
            string sqlQuery2 = "INSERT INTO Records (PlayerID, Record, DateRecorded) VALUES ((SELECT PlayerID FROM Players ORDER BY PlayerID DESC LIMIT 1), \"No record\", Date('now'));";
            dbcmd.CommandText = sqlQuery2;
            IDataReader reader2 = dbcmd.ExecuteReader();

            reader2.Close();
            reader2 = null;

            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;

            AfterCreateSetActive();
        }
    }
    

    private void AfterCreateSetActive() {
        SceneTitle.SetActive(false);
        Inputs.SetActive(false);
        AfterCreate.SetActive(true);
        
        DisplayName.text = name;
        DisplayAge.text = Convert.ToString(age);
        if (sex == "f") {
            DisplaySex.text = "female";
        } else {
            DisplaySex.text = "male";
        }
        DisplayRemarks.text = remarks;
    }


    public void Home() {
        SceneManager.LoadScene(0);
    }
    
    public void OpeningGameScene() {
        SceneManager.LoadScene(3);
    }

}
