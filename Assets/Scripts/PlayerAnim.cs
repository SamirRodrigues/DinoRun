using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustParticle = null;

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
        if (!Player.vivo && dustParticle)
            dustParticle.Stop();
    }

    public void KickAnim()
    {
        if (Input.GetKeyDown(KeyCode.Z)) //Caso precione a tecla Z
        {            
            anim.SetTrigger("Kick"); // Inicia a animação de Kick
        }
    }

    public void HeadAttackAnim()
    {
        if (Input.GetKeyDown(KeyCode.X))    // Caso precione a tecla X
        {           
            anim.SetTrigger("Head");  // Inicia a animação de HeadButt (cabeçada)
        }
    }

    public void JumpAnim()
    {
        if (Input.GetKeyDown(KeyCode.Space))    // Caso precione a tecla SpaceBar
        {
            if (dustParticle)
            {
                dustParticle.Stop();
            }

            anim.SetTrigger("Jump");
        }
    }

    public void NormalRun()
    {
        if (anim != null)
        {
            anim.SetBool("Scared", false);
            anim.SetBool("Run", true);
        }
    }


    public void KilledBySky()
    {
        Player.vivo = false;
        if (anim != null)
            anim.SetTrigger("DeathBySky");
    }

    public void KilledByGround()
    {
        Player.vivo = false;
        if (anim != null)
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
