using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    public int aux = 0; // Responsável por emitir o rugido do Boss, além de registrar o score que o jogo esta quando entrar em cena.
                        // De forma a poder definir uma quantidade específica de score em que ele permanecerá na tela

    //Gerenciador de animações
    public Animator anim;

    public Transform movePosition;          // Ponto onde o boss tem que se mover ao ser chamado para cena
    public Transform backStepPosition;      // Ponto onde o boss tem que se mover depois de aparecer em cena e passar um tempo sem ser necessitado
    public ScoreManeger scoreVerificator;   // Verifica a quantidade de pontos para poder decidir a próxima ação do boss
    private float atualScore = 0;


    //Responsável por gerenciar o som
    public AudioManager bossRoar;

    //Interação com o player
    public KillPlayer kill;
    public DestroyPlayer point;
    public Attack player;
    public PlayerAnim playerAnim;




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

            if (aux == 0)
            {
                bossRoar.PlaySound("BossRoar");
                atualScore = scoreVerificator.scoreCount;
                aux += 1;                
            }
            else if (aux == 1)
            {
                if (scoreVerificator.scoreCount >= (atualScore + 100))
                {
                    playerAnim.anim.SetBool("Scared", false);
                    playerAnim.anim.SetBool("Run", true);
                    missTakesCount = 0;
                    aux = 0;
                }
            }
        } 
        else if (missTakesCount == 0)
        {
            playerAnim.NormalRun();
            transform.position = Vector3.MoveTowards(transform.position, backStepPosition.position, Time.deltaTime * vel);

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
