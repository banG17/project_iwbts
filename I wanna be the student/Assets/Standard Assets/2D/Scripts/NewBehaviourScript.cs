using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{


    public void StartGame()
    {
        Application.LoadLevel("scene");
    }

    public void ManualShow()
    {
        GameObject.FindGameObjectWithTag("Zagolovok").GetComponent<Text>().enabled = false;
        GameObject.FindGameObjectWithTag("Manual").GetComponent<Image>().enabled = true;
    }

    public void ScoreBoardShow()
    {
        Application.LoadLevel("ScoreBoard");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
