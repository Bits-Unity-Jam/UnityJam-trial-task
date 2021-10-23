using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehaving : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField]private float moveSpeed;
    [SerializeField]private float frequency;
    [SerializeField]private float magnitude;

    bool facingRigt = true;

    Vector3 pos, localScale;

    [SerializeField] Transform limitePoint, limitePoint2;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pos = transform.position;
        localScale = transform.localScale;
    }
    private void Update()
    {
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
}
