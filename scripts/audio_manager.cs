
using UnityEngine;

public class audio_manager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;
    public AudioClip backgroundMusic;
    public AudioClip dethMusic;
    public AudioClip spawnMusic;

    public AudioClip jumpMusic;


    // Update is called once per frame
    void Start()
    {

        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
}
