using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] audioClips;

    public AudioSource AudioSourceTemplate;
    private AudioSource[] audioSources = new AudioSource[32];

    public int Volume = 1;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("More than 1 AudioManager exists.");

        for (int i = 0; i < audioSources.Length; i++)
            audioSources[i] = Instantiate(AudioSourceTemplate, transform);
    }

    public void PlaySound(string clipName)
    {
        AudioSource audioSource = null;
        AudioClip audioClip = null;

        //Find Audio Source
        foreach (AudioSource source in audioSources)
        {
            if(!source.isPlaying)
            {
                audioSource = source;
                break;
            }
        }

        if (audioSource == null)
            return;

        //Find Audio Clip from name
        foreach (AudioClip clip in audioClips)
        {
            if(clip.name == clipName)
            {
                audioClip = clip;
                break;
            }
        }

        if (audioClip == null)
        {
            Debug.LogError("Failed to find sound: " + clipName);
            return;
        }

        audioSource.clip = audioClip;
        audioSource.volume = Volume;
        audioSource.Play();

    }

    
}
