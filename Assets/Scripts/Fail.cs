using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    public IABoss boss; // Interações com o boss
    public PlayerAnim player;

    public void Topada()
    {
        player.TopadaAnim();    // Animação de corrida assustada
        boss.missTakesCount += 1;          // Chama o boss        
    }
}
