using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public string soundName;
    public bool isPause;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Play()
    {
        audioSource.Play();
    }

    public void PlaySound(bool absoluteStart = false)
    {
        if (!absoluteStart && isPause)
        {
            UnPauseSound();
        }

        if (audioSource.isPlaying)
        {
            return;
        }

        Play();
    }

    public void StopSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        isPause = false;
    }
    
    public void PauseSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }

        isPause = true;
    }
    
    public void UnPauseSound()
    {
        if (isPause)
        {
            audioSource.UnPause();
            isPause = false;
        }
    }
}
