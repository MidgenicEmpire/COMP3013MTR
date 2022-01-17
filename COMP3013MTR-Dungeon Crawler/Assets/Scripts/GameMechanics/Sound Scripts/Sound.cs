using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{

    public string Name;

    public AudioClip sClip;

    //Future Implementation
    [Range(0f,4f)]
    public float Volume;

    [Range(0f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;



}
