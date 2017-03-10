using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw_move_verticaly : MonoBehaviour {
    [SerializeField]private float from = 0;
    [SerializeField]private float to = 0;
    [SerializeField]private float speed = 0;
    [SerializeField]private bool turn = false;

    private Rigidbody2D m_Rigidbody2D;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (gameObject.transform.position.y >= from) turn = true;
        else if (gameObject.transform.position.y <= to) turn = false;
        if (!turn) m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, 1f*speed); 
        else m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -1f*speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
