using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class Database1 : MonoBehaviour
{

    void Start()
    {
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        //dbconn.SetPassword("vrthesis");
        Debug.Log("new sqlite conn");
        dbconn.Open(); //Open connection to database
        Debug.Log("db open");

        dbconn.Close();
        dbconn = null;
        Debug.Log("Fin yaay");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
