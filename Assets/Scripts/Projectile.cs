using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 tf = new Vector3(transform.position.x - 2, transform.position.y, transform.position.2);
        //transform.position = Vector2.MoveTowards(tf, player.position, speed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
        //    DestroyProjectTile();
        //}
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        DestroyProjectTile();
    //    }
    //}

    //void DestroyProjectTile
    //{ 
    //    Destroy(gameObject);
    //}
}
