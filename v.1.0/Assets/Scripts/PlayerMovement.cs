using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator; /*Animacion Jugador*/
    private float Horizontal;
    private bool Grounded;

    [SerializeField] private AudioClip saltoSonido;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();/*Animacion*/
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-0.4898234f, 0.4898234f, 0.4898234f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(0.4898234f, 0.4898234f, 0.4898234f);

       Animator.SetBool("running", Horizontal != 0.0f);  /*Animacion*/

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            ControladorSonido.Instance.EjecutarSonido(saltoSonido);
        }

    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);
    }

}
