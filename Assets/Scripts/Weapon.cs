using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shotpos;
    public GameObject Bullet;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetBool("attack", true);
            Instantiate(Bullet, shotpos.transform.position, transform.rotation);
        }
        else 
        {
            anim.SetBool("attack", false);
        }
    }
}
