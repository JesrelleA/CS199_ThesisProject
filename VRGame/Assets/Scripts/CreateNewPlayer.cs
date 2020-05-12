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

    public TextMeshProUGUI DisplayValFN;
    public TextMeshProUGUI DisplayValLN;
    public TextMeshProUGUI DisplayValA;
    public TextMeshProUGUI DisplayValS;
    public TextMeshProUGUI DisplayValR;
    public TextMeshProUGUI Name;
    public GameObject AfterCreate;

    public void Start() {
        
    }

    public void Trythis() {
        firstname = GameObject.Find ("FirstNameInput").GetComponent<InputField>().text;
        Debug.Log(firstname);
        lastname = GameObject.Find ("LastNameInput").GetComponent<InputField>().text;
        name = firstname + " " + lastname;
        Debug.Log(name);

        var togglecheck = GameObject.Find ("Male");
        var toggle2 = GameObject.Find ("Female");
        //togglecheck.GetComponent<Toggle>().isOn = true;
        var ismale = togglecheck.GetComponent<Toggle>().isOn;

        Debug.Log(ismale);

        if (togglecheck.GetComponent<Toggle>().isOn) {
            Debug.Log("male");
        }

        if (toggle2.GetComponent<Toggle>().isOn) {
            Debug.Log("female");
        }
        
        
    }

    
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
            Debug.Log("new sqlite conn");
            dbconn.Open(); //Open connection to database
            Debug.Log("db open");

            IDbCommand dbcmd = dbconn.CreateCommand();

            //Insert to Players
            string sqlQuery = "INSERT INTO Players(Name, Age, Sex, Remarks) VALUES (\"" + name + "\", " + age + ", \"" + sex + "\", \"" + remarks + "\");"; //"INSERT INTO Players(Name, Age, Sex, Remarks) VALUES(\"hello2\", 6, \"f\", \"WORKED YAAAY\");"; //"SELECT * FROM Players;"; //"SELECT Name, Age, Sex, Remarks FROM Players";

            dbcmd.CommandText = sqlQuery;
            Debug.Log(sqlQuery);
            IDataReader reader = dbcmd.ExecuteReader();

            //Debug.Log("before reader close");
            Debug.Log("Inserted to Players");
            reader.Close();
            reader = null;

            //Insert to Records
            string sqlQuery2 = "INSERT INTO Records (PlayerID, Record, DateRecorded) VALUES ((SELECT PlayerID FROM Players ORDER BY PlayerID DESC LIMIT 1), \"No record\", Date('now'));";
            dbcmd.CommandText = sqlQuery2;
            Debug.Log(sqlQuery2);
            IDataReader reader2 = dbcmd.ExecuteReader();

            //Debug.Log("before reader2 close");
            Debug.Log("Inserted to Records");
            reader2.Close();
            //Debug.Log("after reader2 close");
            reader2 = null;
            Debug.Log("after null");


            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
            Debug.Log("Fin yaay");

            AfterCreateSetActive();
            Name.text = name;
            DisplayName(name);

        } else {
            Debug.Log("hmmmm");
        }

        
        
    }
    

    public void AfterCreateSetActive() {
        AfterCreate.SetActive(true);
    }

    public void DisplayName(string name) {
        Name.text = name;
    }

    public void Home() {
        SceneManager.LoadScene(0);
    }
    

}
