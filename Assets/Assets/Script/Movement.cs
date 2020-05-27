using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb;

    Animator anim;

    public float PlayerSpeed = 5f;

    public Rigidbody2D redPotion;

    private float AbsSpeed; 

    private float move;

    public float jumpforce;

    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public float vol = .6f;

    [SerializeField]
    public AudioClip shootSound;

    public AudioSource source;

    private bool isfacingright = true;

    private Transform m_GroundCheck;  
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_GroundedRadius = .7f; // Radius of the overlap circle to determine if grounded

    [SerializeField] private LayerMask m_WhatIsGround;


    private void Awake()
    {
        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();

    }

    void Start () {
	}
	
    void FixedUpdate () {
        

        m_Grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        anim.SetBool("Ground", m_Grounded);

        if (Input.GetButtonDown("Jump") && m_Grounded  )
        {
            
            //rb.AddForce(new Vector2(0f, jumpforce));
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);



        }else if (Input.GetButtonUp("Jump")){
            if (rb.velocity.y > 0)
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * (float) 0.5);
        }

        
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            if(!isfacingright){
                transform.Rotate(Vector3.up * 180);
                isfacingright = true;
            }
            //transform.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
            //rb.AddForce(Vector2.right * (PlayerSpeed * Time.deltaTime));
            rb.velocity = new Vector2(PlayerSpeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(isfacingright){
                transform.Rotate(Vector3.up * 180);
                isfacingright = false;
            }
            //transform.Translate(Vector3.left * -PlayerSpeed * Time.deltaTime);
            //rb.AddForce(Vector2.right * (-PlayerSpeed * Time.deltaTime));
            rb.velocity = new Vector2(-PlayerSpeed, rb.velocity.y);

        }

        if(Input.GetButtonUp("Horizontal")){
            rb.velocity = new Vector2(0f, rb.velocity.y);
            //if (Mathf.Abs(rb.velocity.x) > 0)
              //  rb.velocity.Set(rb.velocity.x * 0.3f, rb.velocity.y);
        }


        //AbsSpeed = Mathf.Abs(Input.GetAxis("Horizontal"));
        AbsSpeed = Mathf.Abs(rb.velocity.x);
        anim.SetFloat("Speed", AbsSpeed);

        if(Input.GetButtonDown("Fire1")){
            Rigidbody2D potion;
            potion = Instantiate(redPotion, transform.position, transform.rotation) as Rigidbody2D;
            //float vol = Random.Range(volLowRange, volHighRange);
            //source.PlayOneShot(shootSound);
            AudioSource.PlayClipAtPoint(shootSound, transform.position, 1f);
           // source.PlayOneShot(shootSound, vol);
            
            if(isfacingright)
                potion.velocity = new Vector2(10f, 4f);
            else
            {
                potion.velocity = new Vector2(-10f, 4f);
            }
        }

	}
}
