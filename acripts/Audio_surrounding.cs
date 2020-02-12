using System;
using UnityEngine;
using UnityEngine.Audio;
public class Audio_surrounding : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.sources=gameObject.AddComponent<AudioSource>();
            s.sources.clip=s.Clip;
            s.sources.volume=s.VVolume;
            s.sources.pitch=s.PPitch;

        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
     Sound s=Array.Find(sounds,sounds=>sounds.name==name);
     if(!s.sources.isPlaying)
     {
s.sources.Play();
     }
     
    }
}
