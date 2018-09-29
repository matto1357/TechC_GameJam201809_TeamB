using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMController : SingletonMonoBehaviour<BGMController> {

    public enum BGMTitle
    {
        Sample,
    }

    [SerializeField]
    List<AudioClip> bgmClips = new List<AudioClip>();

    AudioSource aSource;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    public void BGMStart(BGMTitle bGMTitle)
    {
        aSource.clip = bgmClips[(int)bGMTitle];
        aSource.Play();
    }
}
