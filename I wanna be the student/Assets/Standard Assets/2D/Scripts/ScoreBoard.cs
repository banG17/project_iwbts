using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
    public Text nick;
    public Text score;
    FileInfo f = new FileInfo("scorboard.txt");
    List<Player> lpl=new List<Player>();
   
	// Use this for initialization
	void Start () {
        if (!f.Exists) f.Create();
        StreamReader sr = new StreamReader("scorboard.txt");
        string str = "";
        while (!sr.EndOfStream) 
        {
            str = sr.ReadLine();
            Char delimiter = ' ';
            String[] substrings = str.Split(delimiter);
                Player pl = new Player(substrings[1],substrings[0]);
                lpl.Add(pl);
        }
        sr.Close();
        lpl.Sort((a, b) => a.scInt.CompareTo(b.scInt));
        /*foreach(Player plr in lpl)
        {
            nick.GetComponent<Text>().text += plr.nc + "\n";
            score.GetComponent<Text>().text += plr.sc + "\n";
        }*/
        for (int i = 0; i < 10; i++)
        {
            nick.GetComponent<Text>().text += lpl[i].nc + "\n";
            score.GetComponent<Text>().text += lpl[i].sc + "\n";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Player
{
    public string sc;
    public string nc;
    public int scInt;
    public Player(string s, string n) { sc = s; nc = n; scInt = Convert.ToInt32(s); }
}
