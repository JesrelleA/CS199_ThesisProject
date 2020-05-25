using System.Collections;
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
    private int id;
    private string firstname;
    private string lastname;
    private string name;
    private int age;
    private string sex;
    private string remarks;

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

    // Start is called before the first frame update
    void Start()
    {
        GetDetails();
        DisplayDetails();

        CancelBtn.onClick.AddListener(HandleCancelBtnClick);
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

    } 
}
