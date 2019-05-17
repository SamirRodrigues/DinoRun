using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public PauseMenu gameOverAtive; // Chama a janela de game over

    public IABoss boss; //Interação com o boss

    public Attack killPlayer; //Interação com o player

    public ScoreManeger theScoreManager; // Interação com o Score

    private bool vivo = false; // Informa que o player morreu


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Caso um objeto com tag Enemy entre no meu trigger
        {
            collision.GetComponent<Enemy>().Kill();

            boss.missTakesCount += 1;
            StartCoroutine(Cooldown());            

        }
    }

    public void KillP() //Responsável por poder Matar o player em outros scripts
    {
        StartCoroutine(Instance());
    }

    public IEnumerator Instance()
    {
       
        yield return new WaitForSeconds(1.5f);  // Espera um tempo em segundos para poder executar a próxima linha
 
        gameOverAtive.gameIsOver = true; // Chama tela de Game Over
        yield return new WaitForSeconds(1f);
        theScoreManager.scoreCount = 0; // Reseta o Score para a próxima partida
     
    }

    public IEnumerator Cooldown()
    {
       
        yield return new WaitForSeconds(1.5f);
        boss.missTakesCount += 1;
       
        killPlayer.TakeDamage(vivo);
        StartCoroutine(Instance());
    }
}
