using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndVerification : MonoBehaviour
{

    public Collider2D Collider; // Responsável por permitir Ativar ou Desativar o Verificador

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FailAttack"))  // Se colidir com um verificador
        {            
            Destroy(collision.gameObject);              // Destroi verificador
        }
    }


    public void AtiveVerificator()     // Quando chamado
    {
        Collider.enabled = true;  // Ativa o colisor
    }

    public void DesativeVerificator()  // Quando chamado
    {
        Collider.enabled = false; // Desativa o colisor
    }
}
