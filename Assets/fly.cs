using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fly : MonoBehaviour
{

    SpriteRenderer SpriteRenderer;

    [SerializeField] private GameObject star;

    int sign = 1;

    public float timer = 3.7f;
    [SerializeField]float time;

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        time = timer;
    }

    void Update()
    {

        if (transform.position.x <= -6 || transform.position.x >= 9)
        {
            sign *= -1;
            SpriteRenderer.flipX = !SpriteRenderer.flipX;
        }
        transform.Translate(Vector3.left * sign * 1.3f * Time.deltaTime);

        if (time <= 0)
        {
            Instantiate(star, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
            time = timer;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
