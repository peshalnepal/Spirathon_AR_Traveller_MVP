using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip Clip;
    [Range(0f,1f)]
    public float VVolume;
    [Range(0f,3f)]
    public float PPitch;
    [HideInInspector]
    public AudioSource sources;
}
