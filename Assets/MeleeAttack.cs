using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos; // Posição do ataque
    public LayerMask whatIsEnemy; // O que é inimigo (Quem eu vou atacar)
    public float attackRange; // Alcance do ataque
   
    public bool vivo = true;
       
    
    void Update()
    {
        if (vivo == true)
        {
            TakeDamage(vivo);
            MAttack();
        }
    }
     

    public void TakeDamage(bool vida)
    {
        if (vida == false)
        {
            vivo = false;            
        }

    }
     

    void MAttack()
    {
        if (timeBtwAttack <= 0) //Se o tempo entre um ataque e outro for menor ou igual a 0, então vocÊ pode atacar
        {
            if (Input.GetKey(KeyCode.W))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().Kill();
                   
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
