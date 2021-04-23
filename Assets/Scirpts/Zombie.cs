using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vector3 = System.Numerics.Vector3;

public class Zombie : MonoBehaviour
{
    public float velocidad = 8f;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    

    private bool PosicionA = false;

    private const int Animacion_Caminar = 0;
    private const int Animacion_Morir = 1;
    
    private Animator animator;
    private BoxCollider2D bx;
    
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PosicionA == false)
            {
                sr.flipX = false;
                rb.velocity = new Vector2(velocidad, rb.velocity.y);
            }
            else
            {
                sr.flipX = true;
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Posicion2")
        {
            PosicionA = true;
        }

        if (collision.gameObject.tag == "Posicion1")
        {
            PosicionA = false;
        }


    }
    private void CambiarAnimacion(int animation)
    {
        animator.SetInteger("estado", animation);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "chocazombie")
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

}