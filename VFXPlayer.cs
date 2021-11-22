using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class VFXPlayer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("PARTICLE EFFECTS FOR WALKING WITH SOUND")]
    private ParticleSystem soundWaveEffect;

    [SerializeField]
    [Tooltip("PARTICLE EFFECT FOR KEY COLLECTION")]
    private ParticleSystem keyCollectedEffects;

    [SerializeField]
    [Tooltip("KEY COLLECT SOUND")]
    private AudioClip keyCollected;


    private AudioSource audioSource;
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        keyCollectedEffects.Stop();
    }

    void Update()
    {
        if (rigidBody.velocity != Vector2.zero)
        {
            // ONCE PER STEP
            if (!soundWaveEffect.isPlaying)
            {
                soundWaveEffect.Play();

            }
            // SINGLE FOOTSTEP 
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }
        }
        else
        {
            soundWaveEffect.Stop();
            audioSource.Stop();
        }
    }

    public void KeyCollectedEffects()
    {
        audioSource.PlayOneShot(keyCollected);
        keyCollectedEffects.Play();
    }
}
