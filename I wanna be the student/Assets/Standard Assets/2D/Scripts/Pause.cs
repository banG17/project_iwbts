using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CrossPlatformInput;

public class Pause : MonoBehaviour
{

    public GUISkin myGUI;
    public GUIStyle style;

    private Blur BF;
    private int window = 20;
    private int ScreenWidth;
    private int ScreenHeight;
    private bool menu = false;

    void Start()
    {
        BF = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();

    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Pause"))
        {
            if (!menu)
            {

                BF.enabled = true;
                Time.timeScale = 0;
                menu = true;
                ScreenWidth = Screen.width;
                ScreenHeight = Screen.height;
                window = 0;
            }
            else
            {
                window = 20;
                BF.enabled = false;
                menu = false;
                Time.timeScale = 1;
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = myGUI;
        if (menu)
        {
            if (window == 0)
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 120, 170, 30), "CONTINUE"))
                {
                    window = 20;
                    menu = false;
                    Time.timeScale = 1;
                    BF.enabled = false;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 80, 170, 30), "SCOREBOARD"))
                {
                   
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 40, 170, 30), "MANUAL"))
                {

                }

                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 0, 170, 30), "EXIT"))
                {
                    Application.Quit();
                }
            }
        }
    }
}
