using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    private int gambiarra = 0; // Faz com que o som toque uma unica vez, de forma a tirar ele do loop infinito gerado pelo update


    //Gerenciador de animações
    public Animator anim;


    public Rigidbody2D rb;
    public Transform movePosition; // Ponto onde o boss tem que se mover
    

    //Responsável por gerenciar o som
    public AudioManager bossRoar;

    //Interação com o player
    public KillPlayer kill;
    public DestroyPlayer point;
    public Attack player;




    public float vel = 0.01f;
    public float missTakesCount = 0;
    public bool move = false;

    // Update is called once per frame
    void Update()
    {
        if (missTakesCount == 2)
        {
            anim.SetTrigger("KillPlayer");
            kill.KillP();
            player.TakeDamage(false);
            point.AtiveAnim();
            missTakesCount += 1; // Faz com que a animação seja executada apenas uma vez

        }
        else if (missTakesCount == 1)
        {
            Walk();

            if (gambiarra == 0)
            {
                gambiarra += 1;                
            }
            else if (gambiarra == 1)
            {
                bossRoar.PlaySound("BossRoar");
                gambiarra += 1;
            }
        }
    }

    public void CallBoss()
    {
        missTakesCount += 1;

    }
    
    private void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePosition.position, Time.deltaTime * vel);                  
    }

   


}
