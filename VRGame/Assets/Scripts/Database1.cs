using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class Database1 : MonoBehaviour
{
    /*
    private string firstname;
    private string lastname;
    private string fullname; // = firstname + " " + lastname
    private int age;
    private string sex;
    private string remarks;

    public GameObject fname1;
    public InputField fnameobj;
    public GameObject lnameobj;
    public GameObject ageobj;
    public GameObject sexobj;
    public GameObject remarksobj;
    */

    void Start()
    {
        
        
       
        
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        Debug.Log("new sqlite conn");
        dbconn.Open(); //Open connection to database
        Debug.Log("db open");

        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "INSERT INTO Players(Name, Age, Sex, Remarks) VALUES(\"hello4\", 7, \"m\", \"WzzY\");"; //"SELECT * FROM Players;"; //"SELECT Name, Age, Sex, Remarks FROM Players";

        dbcmd.CommandText = sqlQuery;
        Debug.Log(sqlQuery);
        IDataReader /*var*/ reader = dbcmd.ExecuteReader();

        //Debug.Log("HWEERER");

        
        /*INSERT TO PLAYERS*/
        //INSERT INTO Players(Name, Age, Sex, Remarks) 
        //VALUES

        /* //INSERT TO RECORDS
        INSERT INTO Records (PlayerID, Record, DateRecorded)
        VALUES (
        (SELECT PlayerID FROM Players ORDER BY PlayerID DESC LIMIT 1),
        "No record",
        Date('now')
        );
        */

        /*
        string playername = "sadsfasfd";
        int age1 = 1;
        string playersex = "f";
        string remarks1 = "sdfg";
    
        while (reader.Read()) {
            Debug.Log("inside while 1");
            playername = Convert.ToString(reader[1]);//.GetString(1);
            age1 = Convert.ToInt32(reader[2]);//.GetInt32(0);
            playersex = Convert.ToString(reader[3]);//.GetString(1);
            remarks1 = Convert.ToString(reader[4]);//.GetString(1);
            Debug.Log("Name: " + playername + " Age: " + age1 + " Sex: " + playersex + " Remarks: " + remarks1);
            Debug.Log("inside while 2");
        }
        */
        
        Debug.Log("before reader close");
        reader.Close();
        reader = null;


        string sqlQuery2 = "INSERT INTO Records (PlayerID, Record, DateRecorded) VALUES ((SELECT PlayerID FROM Players ORDER BY PlayerID DESC LIMIT 1), \"No record\", Date('now'));";
        dbcmd.CommandText = sqlQuery2;
        Debug.Log(sqlQuery2);
        IDataReader /*var*/ reader2 = dbcmd.ExecuteReader();

        /*int id = 0;

        while (reader2.Read()) {
            Debug.Log("inside while2");
            id = Convert.ToInt32(reader[0]);
            Debug.Log(id);
        }*/

        Debug.Log("before reader2 close");
        reader2.Close();
        Debug.Log("after reader2 close");
        reader2 = null;
        Debug.Log("after null");



        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        Debug.Log("Fin yaay");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
