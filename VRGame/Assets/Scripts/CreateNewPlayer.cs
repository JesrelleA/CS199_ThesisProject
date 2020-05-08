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
    public string firstname;
    private string lastname;
    private string name;
    private int age;
    private string sex;
    private string remarks;

    Toggle male;
    Toggle female;

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

        //Get values from input fields
        //Name
        firstname = GameObject.Find ("FirstNameInput").GetComponent<InputField>().text;
        Debug.Log(firstname);
        lastname = GameObject.Find ("LastNameInput").GetComponent<InputField>().text;
        name = firstname + " " + lastname;

        //Age
        string agetemp = GameObject.Find ("AgeInput").GetComponent<InputField>().text;
        age = Convert.ToInt32(agetemp);

        //Sex
        var isfemale = GameObject.Find ("Female");
        var ismale = GameObject.Find ("Male");
        if (isfemale.GetComponent<Toggle>().isOn == true) {
            sex = "f";
        }
        if (ismale.GetComponent<Toggle>().isOn == true) {
            sex = "m";
        }

        //Remarks
        remarks = GameObject.Find ("RemarksInput").GetComponent<InputField>().text;

        //Connect ot DB
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
        
    }
    

    public void Home() {
        SceneManager.LoadScene(0);
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
