using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    // Música
    [Header("Music Audio References")]
    [SerializeField] private AudioClip backgroundMusic;

    // Efectos de sonido
    [Header("SFX Audio References")]
    [SerializeField] private AudioClip hey;
    [SerializeField] private AudioClip tireEscaping;
    [SerializeField] private AudioClip buttonPress;

    [SerializeField] private AudioClip tireJump;

    [SerializeField] private AudioClip tireCollision;
    [SerializeField] private AudioClip specialCollision;

    [SerializeField] private AudioClip gameOver;

    void Start()
    {
        PlayMusic(backgroundMusic);
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // FUNCIONES BASE

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    // FUNCIONES ESPECÍFICAS DEL JUEGO

    public void PlayGameStart()
    {
        PlaySFX(hey);
        PlaySFX(tireEscaping);
        PlaySFX(buttonPress);
    }

    public void PlayJump()
    {
        sfxSource.pitch = Random.Range(0.95f, 1.05f);
        PlaySFX(tireJump);
        sfxSource.pitch = 1f;
    }

    public void PlayCollision()
    {
        PlaySFX(tireCollision);
    }

    public void PlaySpecialCollision()
    {
        PlaySFX(specialCollision);
    }

    public void PlayGameOver()
    {
        PlaySFX(gameOver);
    }

    public void PlayButton()
    {
        PlaySFX(buttonPress);
    }
}
