using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Attack : MonoBehaviour
{

    public Transform attackPosKick; // Posição do ataque kick
    public Transform attackPosHead; // Posição do ataque head
    public LayerMask whatIsEnemy; // O que é inimigo (Quem eu vou atacar)
    public float attackRange; // Alcance do ataque
    public int damage; // Variável que verifica se o personagem deu dano ou não
    public bool vivo = true;

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
            GetComponentInChildren<UnlockAttack>().AtiveAttack();

            // Inicia um cooldown para poder desativar o colisor
            cooldownAttack.Play(0.5f); // Duração do Attack (Dura 0,5 segundos)

        }

        if (cooldownAttack.IsFinish() == true) // Verifica se o tempo do cooldown acabou
        {
            // Inicia a animação de corrida
            anim.SetBool("Run", true);
            anim.SetBool("Kick", false);

            GetComponentInChildren<UnlockAttack>().DesativeAttack(); // Desativa o colisor do ataque
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
            GetComponentInChildren<UnlockHeadAttack>().AtiveAttack();

            // Inicia um cooldown para poder desativar o colisor
            cooldownAttack.Play(0.5f); // Duração do Attack (Dura 0,5 segundos)
        }
        
        if (cooldownAttack.IsFinish() == true) // Verifica se o tempo do cooldown acabou
        {
            // Inicia a animação de corrida
            anim.SetBool("Run", true);
            anim.SetBool("Head", false);

            GetComponentInChildren<UnlockHeadAttack>().DesativeAttack(); // Desativa o colisor do ataque
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
        //CHAMA O BOSS
    }


}




