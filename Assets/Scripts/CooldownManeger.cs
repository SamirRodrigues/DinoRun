using UnityEngine;

public class CooldownManeger 
{

    private float nextFireTime = 0; // Inicializa o tempo em zero

    public CooldownManeger() { } //Construtor

    public void Play(float _time)
    {
        // Quando dar o play, recebe o tempo em "_time", essa variável vai ser responsável por definir o tempo do cronômetro
        nextFireTime = Time.time + _time; // Responsável por colocar o tempo atual e somar com o tempo desejado no cronômetro
        
    }

    public bool IsFinish/*?*/()
    {

        if (Time.time > nextFireTime) // Verifica se o tempo atual é maior que o tempo do cronômetro
            //(Ou seja, vai ver se já passou o tempo do cronômetro)
        {
            return true;
            //Se acabou o tempo, retorna true
        }
        else
        {
            return false;
            // Se não acabou o tempo, retorna false.
        }
        
    }
}
