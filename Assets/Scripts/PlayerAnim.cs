using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private int a = 0;
    //Boss interation

    public IABoss boss; // Interações com o boss
    public Attack Player;

    //Animação

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.vivo == true)
        {
            KickAnim();
            HeadAttackAnim();
            JumpAnim();
        }
       
    }

    void KickAnim()
    {
        if (Input.GetKeyDown(KeyCode.W)) //Caso precione a tecla W
        {            
            anim.SetTrigger("Kick"); // Inicia a animação de Kick
        }
    }

    void HeadAttackAnim()
    {
        if (Input.GetKeyDown(KeyCode.Q))    // Caso precione a tecla Q
        {           
            anim.SetTrigger("Head");  // Inicia a animação de HeadButt (cabeçada)
        }
    }

    void JumpAnim()
    {
        if (Input.GetKeyDown(KeyCode.E))    // Caso precione a tecla E
        {
            anim.SetTrigger("Jump");
        }
    }

    public void NormalRun()
    {
        anim.SetBool("Scared", false);
        anim.SetBool("Run", true);
    }


    public void KilledBySky()
    {
        Player.vivo = false;
        anim.SetTrigger("DeathBySky");
    }

    public void KilledByGround()
    {
        Player.vivo = false;
        anim.SetTrigger("DeathByGround");
    }

    public void TopadaAnim()
    {
        anim.SetTrigger("Fail");
        anim.SetBool("Scared", true);
        anim.SetBool("Run", false);
        a += 1;
        if(a == 1)
        {
            boss.missTakesCount += 1;
        }
        else if (a == 2)
        {
            a = 0;
        }
        
    }

}
