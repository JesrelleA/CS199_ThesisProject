using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class Database1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //"/db1.s3db"; //Path to database

        //Debug.Log("hi?");
        Debug.Log(conn);
        //Debug.Log("at least??");
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        Debug.Log("new sqlite conn");
        dbconn.Open(); //Open connection to database
        Debug.Log("db open");

        IDbCommand dbcmd = dbconn.CreateCommand();

        if (dbcmd!= null)
        {
            Debug.Log("IN");
            Debug.Log(dbcmd);
        } else {
            Debug.Log("NOPE :(");
        }

        string sqlQuery = "SELECT * FROM Players;"; //"INSERT INTO Players(Name, Age, Sex, Remarks) VALUES(\"hello2\", 6, \"f\", \"WORKED YAAAY\");"; //"SELECT * FROM Players;"; //"SELECT Name, Age, Sex, Remarks FROM Players";

        dbcmd.CommandText = sqlQuery;
        Debug.Log(sqlQuery);
        IDataReader /*var*/ reader = dbcmd.ExecuteReader();

        Debug.Log("HWEERER");

        
        string playername = "sadsfasfd";
        int age1 = 1;
        string playersex = "f";
        string remarks1 = "sdfg";
    
        
        while (reader.Read()) {
            Debug.Log("inside while 1");
            //Debug.Log(String.Format("{0}", reader[1]));
            playername = Convert.ToString(reader[1]);//.GetString(1);
            age1 = Convert.ToInt32(reader[2]);//.GetInt32(0);
            playersex = Convert.ToString(reader[3]);//.GetString(1);
            remarks1 = Convert.ToString(reader[4]);//.GetString(1);
            Debug.Log("Name: " + playername + " Age: " + age1 + " Sex: " + playersex + " Remarks: " + remarks1);
            Debug.Log("inside while 2");
        }
        
        //Debug.Log("name=" + playername + " age=" + age1 + " sex=" + playersex + " remarks=" + remarks1);
        

        Debug.Log("before reader close");
        reader.Close();
        reader = null;
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
