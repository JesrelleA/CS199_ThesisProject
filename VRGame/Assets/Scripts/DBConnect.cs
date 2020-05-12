using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBConnect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       /* string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database
        Debug.Log(conn);

        IDbConnectionExtension dbconn;
        dbconn = (IDbConnectionExtension)new SqliteConnection(conn);
        Debug.Log("ok");
        dbconn.Open();
        Debug.Log("db open");

        dbconn.Close();
        dbconn = null;
        Debug.Log("Fin yaay");
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
