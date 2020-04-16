using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ViewPlayers : MonoBehaviour
{

    private int playerTotalNum; 
    public TextMeshProUGUI DisplayName; 
    public TextMeshProUGUI DisplayAge;
    public TextMeshProUGUI DisplaySex;
    public TextMeshProUGUI DisplayRemarks;
    private string name = "Helena";
    private int age = 8;
    private string sex = "female";
    private string remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

    void Start() {
        DisplayNameText();
        DisplayAgeText();
        DisplaySexText();
        DisplayRemarksText();
    }

    /*public void ViewDetails() {
        DisplayNameText();
        DisplayAgeText();
        DisplaySexText();
        DisplayRemarksText();
    }*/

    public void Home() {
        SceneManager.LoadScene(0);
    }

    public void DisplayNameText() {
        DisplayName.text = name;
        Debug.Log("please :("); 
    }

    public void DisplayAgeText() {
        DisplayAge.text = age.ToString();
    }

    public void DisplaySexText() {
        DisplaySex.text = sex;
    }

    public void DisplayRemarksText() {
        DisplayRemarks.text = remarks;
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
