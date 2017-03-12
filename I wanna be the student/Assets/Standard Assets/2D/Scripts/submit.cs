using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class submit : MonoBehaviour {
    public Button myButton;
    public InputField myInput;
    public Text myText;
    public Text deaths;
    FileInfo f = new FileInfo("scorboard.txt");

    void Start()
    {
        if (!f.Exists) f.Create();
        Button btn = myButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        
        Text t = myText.GetComponent<Text>();
        Text d = deaths.GetComponent<Text>();
        InputField inp = myInput.GetComponent<InputField>();
        if (inp.text == "") t.color = Color.red;
        else
        {
            t.color = Color.white;
            StreamWriter sw;
            f = new FileInfo("scorboard.txt");
            sw = f.AppendText();
            sw.WriteLine(inp.text+" "+d.text);
            sw.Close();
            Application.LoadLevel("menu");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
