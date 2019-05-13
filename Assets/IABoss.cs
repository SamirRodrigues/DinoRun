using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IABoss : MonoBehaviour
{
    public float missTakesCount = 0;

    public Animator anim;

    public DestroyPlayer point;

    public Attack player;

    public AudioManager bossRoar;

    public KillPlayer kill;

    public float vel = 0.01f;
    public bool move = false;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(missTakesCount);
        if (missTakesCount == 2)
        {
            anim.SetTrigger("KillPlayer");
            missTakesCount += 1;
            kill.KillP();
            player.TakeDamage(false);
            point.AtiveAnim();

        }
        else if (missTakesCount == 1 /* && missTakesCount <= 2*/)
        {
            Walk();
        }
    }

    public void CallBoss()
    {
        missTakesCount += 1;

    }

    void Walk()
    {
        if (move == true)
        {
            transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0)); // Move o Boss para Direita
            
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
