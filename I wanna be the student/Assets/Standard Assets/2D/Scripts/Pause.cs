using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;

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
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 100, 170, 30), "CONTINUE"))
                {
                    window = 20;
                    menu = false;
                    Time.timeScale = 1;
                    BF.enabled = false;
                }
             
                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 60, 170, 30), "MANUAL"))
                {
                   
                    window = 1;
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 70, Screen.height / 2 - 20, 170, 30), "EXIT"))
                {
                    Application.Quit();
                }
                if (window == 1)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
                    BF.enabled = false;
                    GameObject.FindGameObjectWithTag("Manual").GetComponent<Image>().enabled = true;   
                }
            }
        }
    }
}
