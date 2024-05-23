using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip ResetButtonClip;
    public AudioClip GameOverClip;
    public AudioClip TieGameClip;
    public AudioClip GameModeClip;
    public List<AudioClip> MarkerSoundClips;

    private List<int> markerSoundQueue;

    public void Reset()
    {
        InitializeMarkerSoundQueue();
    }

    public void PlayRandomMarkerSound()
    {
        if (markerSoundQueue.Count == 0)
            InitializeMarkerSoundQueue();
        
        int indexToPlay = markerSoundQueue[0];
        markerSoundQueue.RemoveAt(0);

        AudioSource.clip = MarkerSoundClips[indexToPlay];
        AudioSource.Play();
    }
    public void PlayResetButtonSound()
    {
        AudioSource.clip = ResetButtonClip;
        AudioSource.Play();
    }
    
    public void PlayGameOverSound()
    {
        AudioSource.clip = GameOverClip;
        AudioSource.Play();
    }
    
    public void PlayTieGameSound()
    {
        AudioSource.clip = TieGameClip;
        AudioSource.Play();
    }
    
    public void PlayGameModeSound()
    {
        AudioSource.clip = GameModeClip;
        AudioSource.Play();
    }

    private void InitializeMarkerSoundQueue()
    {
        List<int> numberPool = new List<int>();
        for (int i = 0; i < MarkerSoundClips.Count; i++)
            numberPool.Add(i);

        markerSoundQueue = new List<int>();
        for (int i = 0; i < MarkerSoundClips.Count; i++)
        {
            int randomIndex = Random.Range(0, numberPool.Count);
            markerSoundQueue.Add(numberPool[randomIndex]);
            numberPool.RemoveAt(randomIndex);
        }
        
    }
}
