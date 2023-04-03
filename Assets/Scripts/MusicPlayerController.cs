using UnityEngine;

/// <summary>
/// Висит на GameController. Проигрывает фоновую музыку.
/// </summary>
public class MusicPlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    private AudioSource audioSource;
    private int index;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clips[0];
        audioSource.Play();
    }

    private void FixedUpdate()
    {
        ChangeClip();
    }

    private void ChangeClip()
    {
        if (audioSource.isPlaying)
            return;
        
        index++;
        if(index >= clips.Length - 1)
            index= 0;
        
        audioSource.clip = clips[index];
        audioSource.Play();
    }
}
