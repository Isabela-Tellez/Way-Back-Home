using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    private float h;

    private SpriteRenderer sr;

    private Vector2 direccionRay;

    private Animator Myanim;

    [Header("Parametros Personaje")] //Titulos en el Editor
    public float hp;
    public Slider BarraVida;
    public float speed;
    public float jumpspeed;

    [Space(10)] //Espacio entre Variables

    [Header("Combate")]
    public float dmg;
    public float ShootRange;
    public GameObject prefabBala;
    public Transform PuntoDisparoDer;
    public Transform PuntoDisparoIzq;

    [Header("Sonidos")]
    public EffectsController Sonido1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        direccionRay = new Vector2(-1, 0);

        Myanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BarraVida.value = hp;

        Movement();

        //Si pulso espacio Salta
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //Disparo Normal
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Disparo();
        }

        //Disparo Especial
        //if (Input.GetKeyDown (KeyCode.Mouse1))
        {
            DisparoEspecial();
        }

        //Rayo solo para el Editor
        Debug.DrawRay(transform.position, direccionRay, Color.red);
    }

    public void Movement()
    {
        h = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2 (h, 0) * speed * Time.deltaTime);

        //Cambiar de dirección a la Derecha

        if (h == 0)
        {
            Myanim.Play("Idle");
        }
        if (h > 0)
        {
            sr.flipX = false;
            direccionRay = Vector2.right;
            Myanim.Play("Walk");
        }

        //Cambiar de dirección a la Izquierda
        if (h < 0)
        {
            sr.flipX = true;
            direccionRay = Vector2.left;
            Myanim.Play("Walk");
        }
    }

    public void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.8f, LayerMask.GetMask("Terreno"));

        Debug.DrawRay(transform.position, Vector2.down * 1.4f, Color.red);

        if (hit)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
            Sonido1.EfectoSonido();
            Myanim.Play("Jump");
        }
    }

    public void Disparo()
    {
        //Raycast para el Disparo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, ShootRange, LayerMask.GetMask("Enemigo"));

        //Imprimir Rayo por la Escena del Editor
        Debug.DrawRay(transform.position, direccionRay, Color.blue);

        if (hit)
        {
            hit.transform.GetComponent<EnemyController>().TakeDmg(dmg);
        }

        if (sr.flipX == false)
        {
            GameObject obj;
            obj = Instantiate(prefabBala, PuntoDisparoIzq.position, Quaternion.identity);
            obj.GetComponent<BulletController>().dir = Vector2.right;
        }

        else
        {
            GameObject obj;
            obj = Instantiate(prefabBala, PuntoDisparoDer.position, Quaternion.identity);
            obj.GetComponent<BulletController>().dir = Vector2.left;
        }
    }

    public void DisparoEspecial()
    {
        if (sr.flipX == false)
        {
            GameObject obj;
            obj = Instantiate(prefabBala, PuntoDisparoIzq.position, Quaternion.identity);
            obj.GetComponent<BulletController>().dir = Vector2.left;
        }

        else
        {
            GameObject obj;
            obj = Instantiate(prefabBala, PuntoDisparoDer.position, Quaternion.identity);
            obj.GetComponent<BulletController>().dir = Vector2.right;
        }
    }

    public void TakeDmg (float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        SceneManager.LoadScene("Died");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trampa")
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Move_Plataforma")
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent = null;
    }
}
