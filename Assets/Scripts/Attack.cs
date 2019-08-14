using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{
    private PlayerAnim playerAnim = null;

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

    [SerializeField] private float cooldownAttack = 1.0f;
    public Cooldown cdAttack;


    private void Awake()
    {
        playerAnim = GetComponent<PlayerAnim>();

        cdAttack = new Cooldown(cooldownAttack);
        cdAttack.Start();
    }

    void Start()
    {       
        audioSrc = GetComponent<AudioSource>();
    }


    void Update()
    {

        if (vivo == true)
        {
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


    public void Kick()
    {
        if (cdAttack.IsFinished) // Verifica se o tempo do cooldown acabou
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosKick.position, attackRange, whatIsEnemy); //Cria um trigger para verificar quantos inimigos estão na área de contato

            if (enemiesToDamage.Length > 0) // Se a quantidade de inimigos dentro da área for maior que 0
            {
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().Kill(); // Mata todos os inimigos que estão na área

                }
            }

            playerAnim.KickAnim();
            cdAttack.Start();
        }

    }

    public void HeadAttack()
    {
        if (cdAttack.IsFinished) // Verifica se o tempo do cooldown acabou
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosHead.position, attackRange, whatIsEnemy); // Cria um trigger para verificar quantos inimigos estão na área de contato

            if (enemiesToDamage.Length > 0) // Se a quantidade de inimigos dentro da área for maior que 0
            {
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().Kill(); // Mata todos os inimigos que estão na área

                }
            }

            playerAnim.HeadAttackAnim();

            cdAttack.Start();
        }
    }

    public void Jump()
    {
        if (qtdPulo > 0)
        {
            rbPlayer.AddForce(new Vector2(0, jump_force));
            qtdPulo -= 1;

            playerAnim.JumpAnim();
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