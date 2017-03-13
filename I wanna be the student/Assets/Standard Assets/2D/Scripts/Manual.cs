﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using System;

public class Manual : MonoBehaviour {
    private Blur BF;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		    if(Input.GetKeyDown(KeyCode.Escape) && GameObject.FindGameObjectWithTag("Manual").GetComponent<Image>().enabled)
            {
            BF = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Blur>();
            BF.enabled = false;
            GameObject.FindGameObjectWithTag("Manual").GetComponent<Image>().enabled = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = true;
            }

            
	}
}
