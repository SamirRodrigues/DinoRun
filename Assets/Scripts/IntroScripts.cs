using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayGame());
    }

    public IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(7.3f);
        SceneManager.LoadScene("Game");
    }
}
