using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    
    public AudioClip backgroundMusic;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }
    
}
