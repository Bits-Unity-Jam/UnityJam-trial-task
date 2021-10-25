using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;


public class Player1 : MonoBehaviour
{

    public Slider slider;
    public float speed;
    private float moveInput;
    private Rigidbody2D rb;
    public bool faceRight = true;

    private Animator anim;
    public int MaxHealth;
    public int health;
    public float Jumpforce;
    public bool isGround;
    public Transform groundCheak;
    private int ExtraJump;
    public int extraJumpValue;
    public float cheakRadius;
    public LayerMask WhatIsGround;
    public int damage;
    //Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        slider.maxValue = MaxHealth;
        slider.value = health;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGround == true)
        {
            ExtraJump = extraJumpValue;
        }
        else
        {
            anim.SetTrigger("jump");
        }

        if (Input.GetKeyDown(KeyCode.Space) && ExtraJump > 0)
        {
            rb.velocity = Vector2.up * Jumpforce;
            ExtraJump--;
          
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ExtraJump == 0 && isGround == true)
        {
            // anim.SetBool("iblast", false);
           

            rb.velocity = Vector2.up * Jumpforce;
        }

       
      

        if (health < 0)
        {
            anim.SetBool("die", true);

            Invoke("Destroy", 1.01f);

            
        }

    }

    void Destroy ()
    {
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheak.position, cheakRadius, WhatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }

        if (faceRight == true && moveInput < 0)
        {
            Flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("run", false);
            
        }
        else
        {
            anim.SetBool("run", true);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            health -= 5;
            anim.SetTrigger("hurt");
        }
    }

    void Flip()
    {
        faceRight = !faceRight;

        transform.Rotate(0f, 180f, 0f);
    }
}
