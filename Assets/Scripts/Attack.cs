using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    //Jump
    public int qtdPulo = 1;
    public float jump_force;
    public Rigidbody2D rbPlayer;


    //Enemy interation

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPosKick; // Posição do ataque kick
    public Transform attackPosHead; // Posição do ataque head
    public LayerMask whatIsEnemy; // O que é inimigo (Quem eu vou atacar)
    public float attackRange; // Alcance do ataque
    public bool vivo = true; // Variável que verifica se o personagem está vivo ou não

    // Sistema de pontuação

    public ScoreManeger theScoreManager;

    //Audio Manager

    public AudioSource audioSrc;

    //Cooldown para verificar o tempo de duração do ataque

    public CooldownManeger cooldownAttack = new CooldownManeger();


    void Start()
    {
       
        audioSrc = GetComponent<AudioSource>();
        cooldownAttack.Play(1.5f); // Duração do Attack (Dura 1,5 segundos)

    }


    void Update()
    {

        if (vivo == true)
        {
            Kick();
            HeadAttack();
            Jump();
            theScoreManager.scoreRun = true;

            if (!audioSrc.isPlaying) // Se o áudio não estiver tocando ainda
            {
                audioSrc.Play(); // Toca o som de Walk
            }

        }
        else
        {
            theScoreManager.scoreRun = false; // Para de incrementar a pontuação            

            audioSrc.Stop(); // Para de tocar o som de Walk
        }
    }


    public void TakeDamage(bool vida)
    {
        if (vida == false)
        {
            vivo = false;
            // Animação de Morte
        }

    }


    void Kick()
    {
        if (cooldownAttack.IsFinish() == true) // Verifica se o tempo do cooldown acabou
        {

            if (Input.GetKeyDown(KeyCode.Z)) //Caso precione a tecla Z
            {
                // Ativa o colisor do Chute
                if (timeBtwAttack <= 0) //Se o tempo entre um ataque e outro for menor ou igual a 0, então vocÊ pode atacar
                {
                    if (Input.GetKey(KeyCode.Z))
                    {
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosKick.position, attackRange, whatIsEnemy); //Cria um trigger para verificar quantos inimigos estão na área de contato

                        if (enemiesToDamage.Length > 0) // Se a quantidade de inimigos dentro da área for maior que 0
                        {
                            for (int i = 0; i < enemiesToDamage.Length; i++)
                            {
                                enemiesToDamage[i].GetComponent<Enemy>().Kill(); // Mata todos os inimigos que estão na área

                            }
                        }
                        else // Caso não tenha inimigos na área
                        {
                            //TopadaAnim(); //Chama a animação de topada junto com o boss
                        }
                    }

                    timeBtwAttack = startTimeBtwAttack;
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }


                // Inicia um cooldown para poder dar o tempo de chamar a animação de corrida

                cooldownAttack.Play(1.5f); // Duração do Attack (Dura 0,5 segundos)
            }

        }

    }

    void HeadAttack()
    {
        if (cooldownAttack.IsFinish() == true) // Verifica se o tempo do cooldown acabou
        {

            if (Input.GetKeyDown(KeyCode.X))    // Caso precione a tecla X
            {
                // Ativa o colisor da Cabeçada
                if (timeBtwAttack <= 0) // Se o tempo entre um ataque e outro for menor ou igual a 0, então vocÊ pode atacar
                {
                    if (Input.GetKey(KeyCode.X))
                    {
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosHead.position, attackRange, whatIsEnemy); // Cria um trigger para verificar quantos inimigos estão na área de contato

                        if (enemiesToDamage.Length > 0) // Se a quantidade de inimigos dentro da área for maior que 0
                        {
                            for (int i = 0; i < enemiesToDamage.Length; i++)
                            {
                                enemiesToDamage[i].GetComponent<Enemy>().Kill(); // Mata todos os inimigos que estão na área

                            }
                        }
                    }

                    timeBtwAttack = startTimeBtwAttack;
                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                }

                // Inicia um cooldown para poder dar o tempo de chamar a animação de corrida
                cooldownAttack.Play(1.5f); // Duração do Attack (Dura 0,5 segundos)
            }
        }
    }

    void Jump()
    {
        if (qtdPulo > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))    // Caso precione a tecla SpaceBar
            {
                rbPlayer.AddForce(new Vector2(0, jump_force));
                qtdPulo -= 1;
            }
        }
    }

    void OnDrawGizmosSelected() // Cria um Gizmo na tela apra que seja possivel ver o a área do colisor mesmo quando ele estiver desativado
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosKick.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPosHead.position, attackRange);
    }

 

    

    void OnCollisionEnter2D(Collision2D AnotherObj) // Função responsável pelas interações com Colisores
    {
        if (AnotherObj.gameObject.CompareTag("Ground")) // Colisão com o Chão
        {
            qtdPulo = 1;
        }
    }
}