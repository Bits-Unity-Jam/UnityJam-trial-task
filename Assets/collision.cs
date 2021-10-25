using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    //[SerializeField] private int gameScore;
    [SerializeField] private Slider scoreBar;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            scoreCount.gameScore++;
            scoreBar.value = scoreCount.gameScore;
            print(scoreBar.value);
        }
    }

    private void Start()
    {
        scoreBar = GameObject.FindGameObjectWithTag("ScoreBar").GetComponent<Slider>();
        scoreBar.maxValue = 10;
        scoreBar.value = scoreCount.gameScore;
    }
}
