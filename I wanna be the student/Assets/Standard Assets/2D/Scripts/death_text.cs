using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class death_text : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = death_count.death.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
