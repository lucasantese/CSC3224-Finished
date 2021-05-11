using UnityEngine;

[DisallowMultipleComponent]
public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    [SerializeField]
     AudioClip[] explosionSounds;
    [SerializeField]
    AudioClip gameOverSound;
    [SerializeField]
    AudioClip shootSound;

    AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("Instance already exists");
        }
    }

    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    public void PlayRandomEplosionSound()
    {
        audioSource.PlayOneShot(explosionSounds[Random.Range(0, explosionSounds.Length)]);
    }

    public void PlayGameOverSound()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
}
