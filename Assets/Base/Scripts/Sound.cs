using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    [SerializeField] private AudioSource prefabSource;
    [SerializeField] private AudioMixerGroup mixerSFX;
    [SerializeField] private AudioMixerGroup mixerMusic;
    public AudioSource curMusic;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public enum PlaySoundFlag
    {
        Loop = 1,
        Global = 1<<1,
    };

    public AudioSource PlaySound(AudioClip[] clip, Transform root, AudioMixerGroup group, PlaySoundFlag flags = 0, float volume = 1f, float pitch = 1f, float minDistance = 8f, float maxDistance = 10)
    {
        AudioClip clipToPlay;
        if (clip.Length > 0)
        {
            int clipIndex = Random.Range(0, clip.Length - 1);
            clipToPlay = clip[clipIndex];
        }
        else
            clipToPlay = clip[0];

        AudioSource audioSource = Instantiate(prefabSource, root.position, Quaternion.identity);

        audioSource.clip = clipToPlay;
        audioSource.outputAudioMixerGroup = group;
        audioSource.loop = ((flags & PlaySoundFlag.Loop) > 0);
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.spatialBlend = 0f;
        
        if ((flags & PlaySoundFlag.Loop) == 0)
            Destroy(audioSource.gameObject, audioSource.clip.length);
        if ((flags & PlaySoundFlag.Global) == 0)
        {
            audioSource.minDistance = minDistance;
            audioSource.maxDistance = maxDistance;
        }

        audioSource.Play();
        return audioSource;
    }

    public AudioSource PlaySFX(AudioClip[] clip, Transform pos, PlaySoundFlag flags = 0, float volume = 1f, float pitch = 1f, float minDistance = 0f, float maxDistance = 500f)
    {
        return PlaySound(clip, pos, mixerSFX, flags, volume, pitch, minDistance, maxDistance);
    }

    public AudioSource PlayMusic(AudioClip[] clip, bool loop = true, float volume = 1f, float pitch = 1f)
    {
        curMusic = PlaySound(clip, this.transform, mixerMusic, (loop == true ? PlaySoundFlag.Loop : 0) | PlaySoundFlag.Global, volume, pitch);
        return curMusic;
    }
}