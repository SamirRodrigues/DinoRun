using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public Rigidbody2D GroundEnemy;
    public float vel = 3f;    

    private bool morto = false;
    public Collider2D e_Ground; // Responsável por permitir editar o collider

    // Animação
    private Animator anim;
    public Renderer Object;

    // Cooldown config
    public CooldownManeger timeDurationAttack = new CooldownManeger();

    void Start()
    {
        anim = GetComponent<Animator>();
        e_Ground = GetComponent<Collider2D>(); // Recebe o collider
        
    }

    void Update()
    {
        Move();
    }


    void OnCollisionEnter2D(Collision2D AnotherObj)      // Função responsável pelas interações com Colisores
    {
        if (AnotherObj.gameObject.CompareTag("Player"))  // Se colidir com um player
        { 
            //Destroy(AnotherObj.gameObject);              // Destroi player

        }
    }

    public void Move() // Irá controlar os movimentos do personagem
    {
        
        if (morto == true) // Se tiver morto 
        {
            anim.SetTrigger("Death");               // Animação de morto
            e_Ground.enabled = false;               // Desativa o collider

            // Tempo de duração até o inimigo ser destruído (usa função cooldown)
            
            if (timeDurationAttack.IsFinish())      // Depois que o tempo do cooldown acabar
            {
                Destroy(gameObject);                // Destroi o inimigo

                // Ou seja, a animação vai ficar acontecendo até que acabe o tempo do cooldown
                // Quando esse tempo acabar, o enemy será destruido e desaparecerá do mapa
            }
        }

        transform.Translate(new Vector3(-vel * Time.deltaTime, 0, 0)); // Move o Enemy para esquerda

    }

    public void Kill()  // Responsável por matar o Enemy
    {
        morto = true; // Informa que o inimigo morreu
        timeDurationAttack.Play(3);   // E informa o tempo que a animação vai durar - Animação vai durar 3 segundos
    }
        
}
