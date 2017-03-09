using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loaded_level : MonoBehaviour {
    [SerializeField] private string levelS = "LVL";

    private GUIStyle lvl = new GUIStyle();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnLevelWasLoaded()
    {
        lvlText();
    }

    bool vis;

    void lvlText()
    {
        StartCoroutine(Mess());
    }
    IEnumerator Mess()
    {
        vis = true;
        yield return new WaitForSeconds(1.5f);
        vis = false;
    }
    void OnGUI()
    {
        Font myFont = (Font)Resources.Load("air_mitalic", typeof(Font));
        if (vis)
        {
            lvl.font = myFont;
            lvl.fontSize = 60;
            lvl.normal.textColor = Color.white;
            GUI.color = Color.white;
            GUI.Label(new Rect(Screen.width / 2 - 10*levelS.Length, Screen.height / 2 - (Screen.height/100)*45, 600, 150), levelS, lvl);
        }

    }
}
