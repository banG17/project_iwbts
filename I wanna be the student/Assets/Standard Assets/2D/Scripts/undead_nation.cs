using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class undead_nation : MonoBehaviour {
    private static undead_nation _instance;

    // Use this for initialization
    void Start () {
        //if we don't have an [_instance] set yet
        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
