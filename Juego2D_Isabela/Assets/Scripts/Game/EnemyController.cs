using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    public float hp;

    public int speed;

    public bool Move;

    private SpriteRenderer sr;
    void Start()
    {
        hp = 6;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Move)
        {
            transform.Translate(2 * Time.deltaTime * speed,0,0);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }
    }

    public void TakeDmg(float dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag =="Return")
        {
            if (Move)
            {
                Move = false;
                sr.flipX = true;
            }

            else
            {
                Move = true;
                sr.flipX = false;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PlayerController>().TakeDmg(5);
        }
    }
}