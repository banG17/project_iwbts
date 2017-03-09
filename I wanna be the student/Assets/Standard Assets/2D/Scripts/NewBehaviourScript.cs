using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{


    public void StartGame()
    {
        Application.LoadLevel(1);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
