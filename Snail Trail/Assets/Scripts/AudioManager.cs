using UnityEngine.Audio;
using UnityEngine;
using System;
public class AudioManager : MonoBehaviour
{
    public sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        sound s= Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
