﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class EditPlayerDetails : MonoBehaviour
{
    private const int V = 1;
    private int id;
    private string firstname;
    private string lastname;
    private string name;
    private int age;
    private string sex;
    private string remarks;
    //private ViewPlayerDetails playerDetailsview;
    private ViewPlayerList viewPlayerList;

    public InputField FirstNameInput;
    public InputField LastNameInput;
    public InputField AgeInput;
    public Toggle FemaleToggle;
    public Toggle MaleToggle;
    public InputField RemarksInput;


    public TextMeshProUGUI DisplayValFN;
    public TextMeshProUGUI DisplayValLN;
    public TextMeshProUGUI DisplayValA;
    public TextMeshProUGUI DisplayValS;
    public TextMeshProUGUI DisplayValR;
    
    public Button CancelBtn;
    public Button SaveBtn;

    public GameObject Image;
    public GameObject PlayerDetails;
    public GameObject EditDetails;

    ViewPlayerDetails viewdetails;

    // Start is called before the first frame update
    void Start()
    {
        GetDetails();
        DisplayDetails();

        CancelBtn.onClick.AddListener(HandleCancelBtnClick);
        SaveBtn.onClick.AddListener(HandleSaveBtnClick);
    }

    private void GetDetails() {
        id = ViewPlayerList.session;

        //Get other data from database
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to database

        IDbCommand dbcmd = dbconn.CreateCommand();

        //query
        string sqlQuery = "SELECT Name, Age, Sex, Remarks FROM Players WHERE PlayerID = " + id;
        //Debug.Log(sqlQuery);

        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            name = reader.GetString(0);
            string[] nametemp = name.Split();
            Debug.Log(nametemp[0]);
            Debug.Log(nametemp[1]);
            firstname = nametemp[0];
            lastname = nametemp[1];
            age = reader.GetInt32(1);
            sex = reader.GetString(2);
            remarks = reader.GetString(3);
        }

        reader.Close();
        reader = null;
    }

    private void DisplayDetails() {
        Debug.Log("Inside display details");
        Debug.Log(firstname);
        Debug.Log(lastname);
        Debug.Log(remarks);
        FirstNameInput.text = firstname;
        LastNameInput.text = lastname;
        AgeInput.text = Convert.ToString(age);
        if (sex == "f") {
            FemaleToggle.isOn = true;
        } else {
            MaleToggle.isOn = true;
        }
        RemarksInput.text = remarks;
    }

    private void HandleCancelBtnClick() {
        DisplayDetails();
        EditDetails.SetActive(false);
        Image.SetActive(true);
        PlayerDetails.SetActive(true);
    }   

    private void HandleSaveBtnClick() {
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
            Debug.Log("first name empty");
            isfirstname = false;
            DisplayValFN.text = "Please enter a first name."; //Display validation text for empty first name
        } else {
            DisplayValFN.text = "";
        }
        Debug.Log(firstname);
        lastname = GameObject.Find ("LastNameInput").GetComponent<InputField>().text;
        if (lastname == "") {
            Debug.Log("last name empty");
            islastname = false;
            DisplayValLN.text = "Please enter a last name."; //Display validation text for empty last name
        } else {
            DisplayValLN.text = "";
        }
        name = firstname + " " + lastname;

        //Age
        string agetemp = GameObject.Find ("AgeInput").GetComponent<InputField>().text;
        if (agetemp == "") {
            Debug.Log("age empty");
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
            Debug.Log("sex empty");
            issex = false;
            DisplayValS.text = "Please choose a sex."; //Display validatio
        } else {
            DisplayValS.text = "";
        }

        //Remarks
        remarks = GameObject.Find ("RemarksInput").GetComponent<InputField>().text;
        if (remarks == "") {
            Debug.Log("remarks empty");
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

            //Update Row on Players Table
            string sqlQuery = "UPDATE Players SET Name = \"" + name + "\", Age = " + age + ", Sex = \"" + sex + "\", Remarks = \"" + remarks + "\" WHERE PlayerID = " + id;

            dbcmd.CommandText = sqlQuery;
            Debug.Log(sqlQuery);
            IDataReader reader = dbcmd.ExecuteReader();

            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            Debug.Log("Player updated");

            //insert a gameobject text: "Player details saved"
            EditDetails.SetActive(false);
            Image.SetActive(true);
            //viewPlayerDetails = FindObjectOfType<ViewPlayerDetails>();
            //viewPlayerDetails.DisplayPlayerDetails();
            //viewPlayerDetails.GetComponent<ViewPlayerDetails>.DisplayPlayerDetails();
            //viewPlayerDetails = gameObject.GetComponent<ViewPlayerDetails>();
            //viewPlayerDetails.GetPlayerDetails();
            //viewPlayerDetails.DisplayPlayerDetails();
            //GameManager gameMananger = GameObject.Find("GameManager").GetComponent<GameManager>();
            //ViewPlayerDetails viewPlayerDetails = GameObject.Find("ViewPlayerDetails").GetComponent<ViewPlayerDetails>();
            
            int updateit = 1;
            //playerDetailsview.GetPlayerDetails();
            //playerDetailsview.updatedetails = updateit;
            
            //viewdetails.updatedetails = 1;
            //viewdetails.GetPlayerDetails();
            PlayerDetails.SetActive(true);
            
        }
    } 
}
