using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_wall : MonoBehaviour {
    [SerializeField]private string side = "right";
    [SerializeField]private float speed = 3f;

    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if(side=="right")
        m_Rigidbody2D.velocity = new Vector2(speed, m_Rigidbody2D.velocity.y);
        else if(side=="left")
        m_Rigidbody2D.velocity = new Vector2(-1f*speed, m_Rigidbody2D.velocity.y);
    }
}
