using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField]private float spawnX = 0;
        [SerializeField]private float spawnY = 0;
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private int jumpcount = 0;
        private GUIStyle diedstyle = new GUIStyle();

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump)
        {


            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce-50*m_Rigidbody2D.velocity.y));
                jumpcount = 1;
            } else if (jump && jumpcount!=2 )
            {
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce - 50 * m_Rigidbody2D.velocity.y));
                jumpcount = 2;
            }
            if (m_Grounded) jumpcount = 0;
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.name == "diecollider")
            {
                gameObject.GetComponent<Platformer2DUserControl>().enabled = false;
                int deathHash = Animator.StringToHash("Death");
                m_Anim.SetTrigger(deathHash);
                diedText();
            }else
            {
                Application.LoadLevel(col.gameObject.name);
            }
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.name == "saw" || col.gameObject.name == "spike" || col.gameObject.name == "spike_wall")
            {
                gameObject.GetComponent<Platformer2DUserControl>().enabled = false;
                int deathHash = Animator.StringToHash("Death");
                m_Anim.SetTrigger(deathHash);
                diedText();
            }
        }

        private void staticobject()
        {
            m_Rigidbody2D.bodyType = RigidbodyType2D.Static;
        }

        private void spawn()
        {
            gameObject.GetComponent<Platformer2DUserControl>().enabled = true;
            m_Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            Application.LoadLevel(Application.loadedLevel);
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        bool vis;

        void diedText()
        {
            StartCoroutine(Mess());
        }
        IEnumerator Mess()
        {
            vis = true;
            yield return new WaitForSeconds(2);
            vis = false;
        }
        void OnGUI()
        {
            Font myFont = (Font)Resources.Load("air_mitalic", typeof(Font));
            if (vis)
            {
                diedstyle.font = myFont;
                diedstyle.fontSize = 60;
                diedstyle.normal.textColor = Color.white;
                GUI.color = Color.white;
                GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - (Screen.height / 100) * 45, 600, 150), "LOL U DIED", diedstyle);
            }

        }

    }
}
