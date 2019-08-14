using UnityEngine;
using UnityEngine.UI;

public class DelayToDesapear : MonoBehaviour
{
    [SerializeField] private float secondsToFade = 2.5f;

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        Invoke("Fade", 0.1f);
    }

    private void Fade()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (1f/(secondsToFade*10)));

        if(text.color.a <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Invoke("Fade", 0.1f);
        }
    }
}
