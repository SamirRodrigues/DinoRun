using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockHeadAttack : MonoBehaviour
{
    public Collider2D Collider; // Responsável por permitir editar o collider do Kick ou do HeadAttack   


    public void Start()
    {
        Collider = GetComponent<Collider2D>(); // Recebe o colisor  
        Collider.enabled = false; //Desativa o colisor
    }

    public void AtiveAttack() // Quando chamado
    {
        Collider.enabled = true; //Ativa o colisor
    }

    public void DesativeAttack() //Quando chamado
    {
        Collider.enabled = false; //Desativa o colisor
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy")) //Caso umobjeto com tag Enemy entre no meu trigger
        {
            collision.GetComponent<Enemy>().Kill(); //Chama a função Kill do cod Enemy (mata meu enemy)
        }
    }

}
