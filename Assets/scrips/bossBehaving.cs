using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bossBehaving : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    private float health;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float frequency;
    [SerializeField]private float magnitude;

    [SerializeField] private Slider healthBar;

    bool facingRigt = true;

    Vector3 pos, localScale;

    [SerializeField] Transform limitePoint, limitePoint2;
    private void Start()
    {
        health = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = transform.position;
        localScale = transform.localScale;
        healthBar.value = CalculateHealth();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 10; 
            healthBar.value = CalculateHealth();
        }
        if (health <= 0)
        {
            Debug.Log("Die");
        }



        CheckWhereToFace();

        if (facingRigt)
        {
            MoveRight();
        }
        else MoveLeft();
    }
    void CheckWhereToFace()
    {
        if (pos.x < limitePoint.position.x)
        {
            facingRigt = true;
        }
        else if (pos.x> limitePoint2.position.x)
        {
            facingRigt = false;
        }
        if (((facingRigt) && (localScale.x < 0)) || ((!facingRigt) && (localScale.x > 0)))
            localScale.x *= -1;
        transform.localScale = localScale;
    }
    void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time*frequency) * magnitude;
    }
    void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
           //this.health -= collision.gameObject.damage;
        }
    }

    float CalculateHealth()
    {
        print(health / MaxHealth);
        return health / MaxHealth; 
    }
}
