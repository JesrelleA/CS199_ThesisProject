using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CreateNewPlayer : MonoBehaviour
{
    public string firstname;
    private string lastname;
    private string name;
    private int age;
    private string sex;
    private string remarks;
    

    public InputField firstnameinput;
    public InputField lastnameinput;
    public InputField ageinput;
    //public InputField sex;
    public Toggle maleinput;
    public Toggle femaleinput;
    public InputField remarksinput;

    public void Start() {
        
    }

    public void Trythis() {
        //firstname = firstnameinput.text(); //firstnameinput.GetComponent<Text>();
        //Debug.Log(firstname);

        //var try2 = firstnameinput.GetComponent<Text>();
        //Debug.Log(try2.text);

        //firstname = firstnameinput.text;
        firstname = GameObject.Find ("FirstNameInput").GetComponent<InputField>().text;
        Debug.Log(firstname);
        lastname = GameObject.Find ("LastNameInput").GetComponent<InputField>().text;
        name = firstname + " " + lastname;
        Debug.Log(name);
    }

    /*
    public void CreatePlayer() {
        string conn = "URI=file:" + Application.dataPath + "/gamedb.s3db;"; //Path to database

        Debug.Log(conn);
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        Debug.Log("new sqlite conn");
        dbconn.Open(); //Open connection to database
        Debug.Log("db open");

        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT * FROM Players;"; //"INSERT INTO Players(Name, Age, Sex, Remarks) VALUES(\"hello2\", 6, \"f\", \"WORKED YAAAY\");"; //"SELECT * FROM Players;"; //"SELECT Name, Age, Sex, Remarks FROM Players";

        dbcmd.CommandText = sqlQuery;
        Debug.Log(sqlQuery);
        IDataReader /*var*/ //reader = dbcmd.ExecuteReader();

        //Debug.Log("HWEERER");

        
        /*INSERT TO PLAYERS*/
        //INSERT INTO Players(Name, Age, Sex, Remarks) 
        //VALUES

        /*INSERT TO RECORDS*/
        //INSERT INTO Records (PlayerID, Record, DateRecorded)
        //VALUES (
        //(SELECT PlayerID FROM Players ORDER BY PlayerID DESC LIMIT 1),
        //"No record",
        //Date('now')
        //);

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
        /*
        Debug.Log("before reader close");
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
        Debug.Log("Fin yaay");
        
    }
    */

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
