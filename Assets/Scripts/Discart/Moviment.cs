using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    public float jump_force = 350f;
    public float dash = 100f;
    public float pushback = -100f;

    public Collider2D colliderAttack;

    public Rigidbody2D Player;
    //private bool liberaPulo = false;
    public int duplo = 1;
    public float vel = 3f;

    private Animator anim;
    private bool vivo = true;

    private bool face = true;
    public Transform playerX;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerX = GetComponent<Transform>();

        anim.SetBool("Idle", false);
        anim.SetBool("Move", true);
    }

    
    void Update()
    {
        if (vivo == true)
        {
            Animate();
            Jump();
            Dash();
            Move();
        }
    }
    
    void Jump() // Nessa função o personagem irá pular
    {
        if (duplo > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Player.AddForce(new Vector2(0, jump_force * Time.deltaTime), ForceMode2D.Impulse);
                duplo -= 1;
            }
        }

    }

    
   void Dash() // Nessa função o personagem irá dar um Dash (Movimentar para frente de maneira mais rápida)
   {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Player.AddForce(new Vector2(dash * Time.deltaTime, 0), ForceMode2D.Impulse);
        }

   }
    

    void Move() // Irá controlar os movimentos do personagem
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0));
            anim.SetBool("Idle", false);
            anim.SetBool("Move", true);
            

        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0));
            anim.SetBool("Idle", false);
            anim.SetBool("Move", true);
            
        }

        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Move", false);
        }


    }

    void Flip() //Mudar o lado para que o personagem está olhando
    {
        face = !face;

        Vector3 scala = playerX.localScale;
        scala.x *= -1;
        playerX.localScale = scala;

        dash *= -1; 
    }

    void OnCollisionEnter2D (Collision2D AnotherObj) // Função responsável pelas interações com Colisores
    {
        if (AnotherObj.gameObject.CompareTag("Ground")) //Colisão com o Chão
        {
            duplo = 2;
            //liberaPulo = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            colliderAttack.enabled = true;
            Invoke("desactiveCollide", 0.1f);
        }
        else
        {
            if (AnotherObj.gameObject.CompareTag("EnemieGround")) // Colisão com os Inimigos Terrestres
            {
                Player.AddForce(new Vector2(pushback * Time.deltaTime, 0), ForceMode2D.Impulse);
            }

            if (AnotherObj.gameObject.CompareTag("EnemieSky")) //Colisão com os Inimigos Voadores
            {
                Player.AddForce(new Vector2(pushback * Time.deltaTime, 0), ForceMode2D.Impulse);
            }
        }
    }

    /*
    void OnCollisionExit2D(Collision2D AnotherObj)
    {
        if (AnotherObj.gameObject.CompareTag("Ground"))
        {
            liberaPulo = false;
        }
    }
    */

    void OnTriggerEnter2D(Collider2D outro) // Morre se colidir com o Spwaner e com Enemy
    {
        if (outro.gameObject.CompareTag("Spawner")) // Ativa "morte" quando colide com Spawner dos inimigos
        {
            vivo = false;
            anim.SetTrigger("Death");
        }

        else if (outro.gameObject.CompareTag("Enemy")) // Ativa "morte" quando colide com o Boss que está no final do mapa
        {
            vivo = false;
            anim.SetTrigger("Death");
        }
    }

    void Animate()
    {

        if (Input.GetKeyDown(KeyCode.C)) // Animação Resposável pelos ataques 
        {
            anim.SetTrigger("Punch");
        }

    }

    void desactiveCollide()
    {
        colliderAttack.enabled = false;
    }

}