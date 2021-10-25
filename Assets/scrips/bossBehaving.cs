using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bossBehaving : MonoBehaviour
{
    public int damage;
    public int MaxHealth;
    private float curentHealth;
    public Slider slider;
    public GameObject player;
    public Animator anim;
    public float distanceForAtt;
    public GameObject huyniy;
    [SerializeField]private GameObject panel;
    private Animator animPanel;



     void Start()
    {
        slider.maxValue = MaxHealth;
        curentHealth = MaxHealth;
        slider.value = curentHealth;
        huyniy.SetActive(false);
        animPanel = panel.GetComponent<Animator>();
        
    }
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GetDamage(10);
        //}
        if (Vector3.Distance(transform.position,player.transform.position)<=distanceForAtt)
        {
            anim.SetTrigger("attack");
        }
        else
        {
            anim.ResetTrigger("attack");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack();
        }
    }
    void Attack()
    {
        anim.SetBool("attack", true);
        GiveDamage(player);
        anim.SetBool("attack", false);

    }
    void GiveDamage(GameObject player)
    {
        //player.gameObject.GetComponent<Player1>.health -= damage;
    }
    void GetDamage(int damage)
    {
        curentHealth -= damage;
        slider.value = curentHealth;
        if (curentHealth <= MaxHealth / 2)
        {
            huyniy.SetActive(true);
        }
        if (IsDead())
        {
            Dead();
        }
    }
    bool IsDead() => curentHealth <= 0;
    void Dead()
    {
        print("dead");
        anim.SetTrigger("IS_dead");
        Invoke("Destroy", 2);
    }
    void Destroy()
    {
        Destroy(gameObject);
        animPanel.SetBool("END", true);

    }

}
