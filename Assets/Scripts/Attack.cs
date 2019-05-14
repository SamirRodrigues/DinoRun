using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    //Boss interation

    public IABoss boss; // Interações com o boss
    public GameObject Player;

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

    //Animação

    public Animator anim;

    //Audio Manager

    public AudioSource audioSrc;

    //Cooldown para verificar o tempo de duração do ataque

    public CooldownManeger cooldownAttack = new CooldownManeger();

    
    void Start()
    {       
        anim = GetComponent<Animator>();
        audioSrc = GetComponent<AudioSource>();

    }


    void Update()
    {
            
        if (vivo == true)
        {
            Kick();
            HeadAttack();
            theScoreManager.scoreIncreasing = true;

            if (!audioSrc.isPlaying) // Se o áudio não estiver tocando ainda
            {
                audioSrc.Play(); // Toca o som de Walk
            }
            
        }
        else
        {
            theScoreManager.scoreIncreasing = false; // Para de incrementar a pontuação            

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
        if (Input.GetKeyDown (KeyCode.W)) //Caso precione a tecla W
        {
            // Inicia a animação de Kick
            anim.SetBool("Run", false);
            anim.SetBool("Kick", true);

            // Ativa o colisor do Chute
            if (timeBtwAttack <= 0) //Se o tempo entre um ataque e outro for menor ou igual a 0, então vocÊ pode atacar
            {
                if (Input.GetKey(KeyCode.W))
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
                        topadaAnim(); //Chama a animação de topada junto com o boss
                    }
                }

                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }


            // Inicia um cooldown para poder dar o tempo de chamar a animação de corrida
            cooldownAttack.Play(0.5f); // Duração do Attack (Dura 0,5 segundos)

        }

        if (cooldownAttack.IsFinish() == true) // Verifica se o tempo do cooldown acabou
        {
            // Inicia a animação de corrida
            anim.SetBool("Run", true);
            anim.SetBool("Kick", false);
        }
        
    }

    void HeadAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q))//Caso precione a tecla Q
        {
            // Inicia a animação de HeadButt (cabeçada)
            anim.SetBool("Run", false);
            anim.SetBool("Head", true);

            // Ativa o colisor da Cabeçada
            if (timeBtwAttack <= 0) //Se o tempo entre um ataque e outro for menor ou igual a 0, então vocÊ pode atacar
            {
                if (Input.GetKey(KeyCode.W))
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
                        topadaAnim(); //Chama a animação de topada junto com o boss
                    }
                }

                timeBtwAttack = startTimeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }

            // Inicia um cooldown para poder dar o tempo de chamar a animação de corrida
            cooldownAttack.Play(0.5f); // Duração do Attack (Dura 0,5 segundos)
        }
        
        if (cooldownAttack.IsFinish() == true) // Verifica se o tempo do cooldown acabou
        {
            // Inicia a animação de corrida
            anim.SetBool("Run", true);
            anim.SetBool("Head", false);
        }
    }


    void OnDrawGizmosSelected() // Cria um Gizmo na tela apra que seja possivel ver o a área do colisor mesmo quando ele estiver desativado
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosKick.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPosHead.position, attackRange);
    }   

    public void topadaAnim()
    {
        anim.SetTrigger("Topada");         // Inicia a animação da Topada
        boss.missTakesCount += 1;          // Chama o boss
        boss.move = true;                  // Faz o boss se mover para frente
    }
}




