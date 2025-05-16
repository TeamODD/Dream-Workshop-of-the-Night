using UnityEngine;

public class PaperMusic : MonoBehaviour
{
    private AudioSource musicSource;
    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
    }

    public void OnPlayMusic()
    {
        if (musicSource != null)
        {
            musicSource.Play();
        }
    }
}
