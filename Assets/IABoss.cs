using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    
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
        
        Debug.Log("Dentro do IABoss: " + missTakesCount);
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
        }
    }

    public void CallBoss()
    {
        missTakesCount += 1;

    }

    

    private void Walk()
    {
        if (move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePosition.position, Time.deltaTime * vel);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            move = false;
            bossRoar.PlaySound("BossRoar");
        }
    }


}
