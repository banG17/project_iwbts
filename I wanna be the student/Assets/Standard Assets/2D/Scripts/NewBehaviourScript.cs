using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{


    public void StartGame()
    {
        Application.LoadLevel(1);
    }

    public void ManualShow()
    {
        GameObject.FindGameObjectWithTag("Manual").GetComponent<Image>().enabled = true;  
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
