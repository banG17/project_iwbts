using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw_move_horizontaly : MonoBehaviour {
    [SerializeField]private float from = 0;
    [SerializeField]private float to = 0;
    [SerializeField]private float speed = 0;

    private Rigidbody2D m_Rigidbody2D;
    private bool turn = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        if (gameObject.transform.position.x >= from) turn = true;
        else if (gameObject.transform.position.x <= to) turn = false;
        if (!turn) m_Rigidbody2D.velocity = new Vector2(1f*speed, m_Rigidbody2D.velocity.y);
        else m_Rigidbody2D.velocity = new Vector2(-1f*speed, m_Rigidbody2D.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
