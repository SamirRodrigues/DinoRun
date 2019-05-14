using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public Animator anim;

    public SelfDestroy player;


    public void AtiveAnim()
    {
        anim.SetTrigger("KillPlayer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("!");
            player.PlayerDestroy();
        }
    }
}
