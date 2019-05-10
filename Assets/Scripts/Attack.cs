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


    //Animação
    
    public Animator anim;



    //Cooldown para verificar o tempo de duração do ataque

    public CooldownManeger cooldownAttack = new CooldownManeger();
    
   

    void Start()
    {       
        anim = GetComponent<Animator>();               
    }


    void Update()
    {
        if (vivo == true)
        {
            TakeDamage(vivo);
            Kick();
            HeadAttack();            
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
        if (Input.GetKeyDown (KeyCode.W) /* && cooldownAttack.IsFinish() == false */)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Kick", true);

            GetComponentInChildren<UnlockAttack>().AtiveAttack();
            cooldownAttack.Play(0.5f); // Duração do Attack (Dura um segundo)

        }

        if (cooldownAttack.IsFinish() == true)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Kick", false);

            GetComponentInChildren<UnlockAttack>().DesativeAttack();
        }
        
    }

    void HeadAttack()
    {
        if (Input.GetKeyDown(KeyCode.Q) /* && cooldownAttack.IsFinish() == false */)
        {            
            anim.SetBool("Run", false);
            anim.SetBool("Head", true);

            GetComponentInChildren<UnlockHeadAttack>().AtiveAttack();
            cooldownAttack.Play(0.5f); // Duração do Attack (Dura um segundo)
        }
        
        if (cooldownAttack.IsFinish() == true)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Head", false);
            GetComponentInChildren<UnlockHeadAttack>().DesativeAttack();
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosKick.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPosHead.position, attackRange);
    }   
    
}




