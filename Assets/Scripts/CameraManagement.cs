using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManagement : MonoBehaviour
{
    //Código responsável por gerenciar a câmera, ele limita até a onde a camerá pode ir e faz com que ela siga o player
    [SerializeField]
    private float xMax = 0; // Máximo range do eixo X
    [SerializeField]
    private float xMin = 0; // Mínimo range do eixo X
    [SerializeField]
    private float yMax = 0; // Máximo range do eixo Y
    [SerializeField]
    private float yMin = 0; // Mínimo range do eixo Y

    private Transform target;


    void Start()
    {
        target = GameObject.Find("Player").transform; // Busca o alvo, no caso "Player"
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Calcula a posição do player e limita a movimentação da câmera conforme os Ranges de X e Y
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax),-10);
    }
}
