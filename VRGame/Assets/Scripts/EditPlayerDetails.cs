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
        id = ViewPlayerList.session;
        Debug.Log(id);

        CancelBtn.onClick.AddListener(HandleCancelBtnClick);
    }

    private void GetDetails() {

    }

    private void HandleCancelBtnClick() {
        EditDetails.SetActive(false);
        Image.SetActive(true);
        if (Image.active) {
            Debug.Log("INSIDE EDIT: Image active");
        } else {
            Debug.Log("INSIDE EDIT: Image not active");
        }
        PlayerDetails.SetActive(true);
    }   

    private void HandleSaveBtnClick() {

    } 
}
