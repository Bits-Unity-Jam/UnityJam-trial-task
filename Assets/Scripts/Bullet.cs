using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool flagJump;
    public GameObject player;
    public float speed;
    private Animator anim;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        flagJump = player.GetComponent<Player1>().flagJump;

        ChangeBullet();


    }
    void ChangeBullet() 
    {

        if (flagJump == true)
        {
             anim.SetBool("iblast", true);
            print("inlasttrue");
        }
        else
        {
            anim.SetBool("iblast", false);


        }

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
