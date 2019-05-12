using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVerification : MonoBehaviour
{


    /* Coloquei dois colliders demarcando o começo e o fim do espaço em que eu gostaria de verificar se tinha um objeto "Enemy" dentro
     * Nesse espaço é instanciado um objeto com um collider que percorre o espaço como um scaner, vendo se o player vai atacar em um momento que não tenha nada dentro do range dele
     * Caso um Enemy entre no range de ataque do player, o verificador é desativado, permitindo que o player ataque sem sofrer debuff
     * O verificador é spawnado no ponto de start e destruido no ponto de end, de forma que não entre em contato com o player, apenas com a área de contato dele.
     * 
     */



    private bool ative = true;         // Variável que Ativa e Desativa o Verificador
    
    public Transform spawner;          // Ponto de Spawn do Verificador
    public Rigidbody2D Verificator;    // Verificador

   
    private IEnumerator Start()
    {
        // Uma rotina que vai executar paralelo ao main code
        yield return new WaitForSeconds(0); // Espera o tempo de 0 segundos para executar a próxima linha (colocado apenas pela necessidade de ter um return)
        StartCoroutine(Instance());         // Chama a rotina assim que começar o jogo
    }

    IEnumerator Instance()
    {

        /* A ideia aqui é que ele espere 0.5 segundos até spawnar o próximo verificador. 
         * Caso ele verifique que um Enemy entrou no range de ataque do player, irá desativar o spawn e esperar 0.5 segundos (Tempo que o player tem para atacar o monstro que entrou no seu range sem ser atingido)
         * até que possa voltar a spawnar verificadores novamente 
         * 
         */

        yield return new WaitForSeconds(0.5f);                              // Espera 0.5 segundos para poder executar a próxima linha

        if (ative == true)  
        {
            GetComponentInChildren<EndVerification>().AtiveVerificator();
            Instantiate(Verificator, spawner.position, spawner.rotation);    // Spawna um verificador
            StartCoroutine(Instance());                                      // Chama novamente a função
            
        }
        
        if (ative == false)
        {
            GetComponentInChildren<EndVerification>().DesativeVerificator();
            yield return new WaitForSeconds(0.5f);
            ative = true;            
            StartCoroutine(Instance());            
        }
    }
      
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))  // Se colidir com um Enemy
        {
            ative = false;                             // Para de spawnar verificadores
        }
    }

    
}
