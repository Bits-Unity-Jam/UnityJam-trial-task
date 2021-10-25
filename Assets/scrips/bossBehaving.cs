using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bossBehaving : MonoBehaviour
{
    public int damage;
    public int MaxHealth;
    public float curentHealth;
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
        if (Input.GetKeyDown(KeyCode.E ))
        {
            GetDamage(10);
        }
        if (Vector3.Distance(transform.position,player.transform.position)<=distanceForAtt)
        {
            anim.SetTrigger("attack");
        }
        else
        {
            anim.ResetTrigger("attack");
        }
        if (scoreCount.gameScore == 10)
        {
            END();
        }
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player1>().health <= 0)
        {
            END();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack();
        }
        if (collision.CompareTag("Bullet"))
        {
           
            GetDamage(5);
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
        player.GetComponent<Player1>().health-=damage;
        player.GetComponent<Player1>().slider.value = player.GetComponent<Player1>().health;

    }
    public void GetDamage(int damage)
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
        END();
    }
    void END()
    {
        animPanel.SetBool("END", true);
    }

}
