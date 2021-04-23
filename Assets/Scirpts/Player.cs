using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour

{
    public float velocidadCorrer = 10;
    private Animator animator;
    private Rigidbody2D rb;
    public float fuerzaSalto = 10f;

    private Transform tr;
    

    private SpriteRenderer sr;

    private const int Animacion_Quieto = 0;
    private const int Animacion_Correr = 2;
    private const int Animacion_Saltar = 3;
    private const int Animacion_Morir = 4;

    private int EstadoSalto = 0;



    public bool EstadoMuerte = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        tr = GetComponent<Transform>();
    }


    void Update()
    {



            if (EstadoMuerte == false)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    MovimientoDerecha();
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    MovimientoIzquierda();
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Saltar();
                }
                

                else
                {
                    EstarQuieto();
                }
            }
            else
            {
                CambiarAnimacion(Animacion_Morir);
                Debug.Log("Muerte");
            }
        
        
    }

    private void CambiarAnimacion(int animation)
    {
        animator.SetInteger("estado", animation);
    }

    private void Saltar()
    {
        rb.velocity = Vector2.up * fuerzaSalto;
        CambiarAnimacion(Animacion_Saltar);

    }

    private void MovimientoIzquierda()
    {
        tr.localScale = new Vector3(-1.3f,1.5f,1);
        rb.velocity = new Vector2(-velocidadCorrer, rb.velocity.y);
        CambiarAnimacion(Animacion_Correr);
        if (Input.GetKey(KeyCode.C))
        {
            CambiarAnimacion(Animacion_Correr);
            tr.localScale = new Vector3(-1.3f,1.5f,1);
            rb.velocity = new Vector2(-velocidadCorrer, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
        }
    }

    private void MovimientoDerecha()
    {
        tr.localScale = new Vector3(1.3f,1.5f,1);
        rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
        CambiarAnimacion(Animacion_Correr);
        if (Input.GetKey(KeyCode.C))
        {
            CambiarAnimacion(Animacion_Correr);
            tr.localScale = new Vector3(1.3f,1.5f,1);
            rb.velocity = new Vector2(velocidadCorrer, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Saltar();
        }
    }

    private void EstarQuieto()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        CambiarAnimacion(Animacion_Quieto);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Muerte")
        {
            EstadoMuerte = true;
        }

        if (collision.gameObject.tag == "Suelo")
        {
            EstadoSalto = 0;
            Debug.Log("aaaaaa");
        }

    }
    
}