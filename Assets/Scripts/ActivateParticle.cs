using UnityEngine;

public class ActivateParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem dustParticle = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground") && dustParticle)
        {
            if (!dustParticle.isPlaying)
            {
                dustParticle.Play();
            }
        }
    }
}
