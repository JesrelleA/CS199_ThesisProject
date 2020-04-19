using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ViewPlayers : MonoBehaviour
{

    //Sample data 
    IList list1 = new ArrayList() {
        "Stephanie Retuya",
        7,
        "female"
    };
    IList list2 = new ArrayList() {
        "Jessica Amornkuldilok",
        9,
        "female"
    };
    IList list3 = new ArrayList() {
        "Kyle Ma",
        6,
        "male"
    };
    IDictionary<int, IList> dict = new Dictionary<int, IList>() {
        {1, list1},
        {2, list2},
        {3, list3}
    };

    private int playerTotalNum = dict.Count; 
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
