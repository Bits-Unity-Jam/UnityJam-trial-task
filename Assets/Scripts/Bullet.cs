using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool isGround;
    public GameObject player;
    public float speed;
    private Animator anim;
    Rigidbody2D rb;
    [SerializeField] private bool IsOnAir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = player.GetComponent<Player1>().isGround;

        ChangeBullet();


    }
    void ChangeBullet() 
    {
        if (transform.position.y > -1.1f)
        {
            IsOnAir = true;
        }
        else
        {
            IsOnAir = false;
        }

        anim.SetBool("iblast", IsOnAir);
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<bossBehaving>().GetDamage(5);
            Destroy(gameObject);

        }
    }
}
