﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAttack : MonoBehaviour
{
    public Collider2D Collider; // Responsável por permitir editar o collider do Kick ou do HeadAttack  


    // Responsável por aumentar o nível de dificuldade do jogo conforme o tempo passa.
   // private float speedLVL = 1f;


    public void Start()
    {
        Collider = GetComponent<Collider2D>(); // Recebe o collider
        Collider.enabled = false;
    }

    public void AtiveAttack()     // Quando chamado
    {
        Collider.enabled = true;  // Ativa o colisor
    }

    public void DesativeAttack()  // Quando chamado
    {
        //Collider.enabled = false; // Desativa o colisor
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Caso um objeto com tag Enemy entre no meu trigger
        {
            // collision.GetComponent<Enemy>().AumentaVel(speedLVL);   // Aumenta a velocidade geral dos meus inimigos para a velocidade de speedLVL
            collision.GetComponent<Enemy>().Kill();                    // Chama a função Kill do cod Enemy (mata meu enemy)      
        }
    }
   
}
