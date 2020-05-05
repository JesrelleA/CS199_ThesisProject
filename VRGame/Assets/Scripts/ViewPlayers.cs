using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ViewPlayers : MonoBehaviour
{

    //Sample data 
    ArrayList list1 = new ArrayList();
    ArrayList list2 = new ArrayList();
    ArrayList list3 = new ArrayList();
    /*Dictionary<int, ArrayList> dict1 = new Dictionary<int, ArrayList>(){
        {1, list1},
        {2, list2},
        {3, list3}
    };*/
    /*
    IDictionary<int, IList> dict = new Dictionary<int, IList>() {
        {1, list1},
        {2, list2},
        {3, list3}
    };
    */

    //private int playerTotalNum = dict.Count; 
    public TextMeshProUGUI DisplayName; 
    public TextMeshProUGUI DisplayAge;
    public TextMeshProUGUI DisplaySex;
    public TextMeshProUGUI DisplayRemarks;
    private string name = "Helena";
    private int age = 8;
    private string sex = "female";
    private string remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";

    /*static void Main(string[] args)
    {
            //Console.WriteLine("Hello World!");
            /*list1.Add("Stephanie Retuya");
            list1.Add(7);
            list1.Add("f");*/
    //}

    void Start(/*string[] args*/) {

        list1.Add("Stephanie Retuya");
        list1.Add(7);
        list1.Add("f");

        list2.Add("Jessica Amornkuldilok");
        list2.Add(8);
        list2.Add("f");

        list3.Add("Kyle Ma");
        list3.Add(6);
        list3.Add("m");

        //dict1.Add(new KeyValuePair<int, ArrayList>(1, list1));
        //dict1.Add(new KeyValuePair<int, ArrayList>(2, list2));
        //dict1.Add(new KeyValuePair<int, ArrayList>(3, list3));

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
