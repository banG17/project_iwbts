using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_back : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("menu");
        }
	}
}
