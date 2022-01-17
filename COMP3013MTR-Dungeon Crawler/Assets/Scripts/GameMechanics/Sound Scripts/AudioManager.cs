using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    private void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sClip;

            s.source.volume = s.Volume;
        }
    }

    public void playSound (string name)
    {
        //finds the right sound and plays it
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        s.source.Play();
        if(s == null)
        {
            Debug.Log("Cannot find your sound");
            return;
        };
    }
}
