using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_spike : MonoBehaviour {

    public GameObject spike;
    private Rigidbody2D m_Rigidbody2D;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            m_Rigidbody2D = spike.GetComponent<Rigidbody2D>();
            m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic; ;
        }
    }
}
