using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_wall : MonoBehaviour {
    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Rigidbody2D.velocity = new Vector2(1f * 3f, m_Rigidbody2D.velocity.y);
    }
}
