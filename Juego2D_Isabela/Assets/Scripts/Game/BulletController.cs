using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    public float dmgBala;
    public Vector2 dir;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * 9 * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemigo")
        {
            collision.transform.GetComponent<EnemyController>().TakeDmg(dmgBala);
        }
    }
}
