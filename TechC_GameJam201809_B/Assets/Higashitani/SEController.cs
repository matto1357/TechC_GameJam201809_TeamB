using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SEController : SingletonMonoBehaviour<SEController> {
    public enum SETitle
    {
        Sample,
    }
    [SerializeField]
    List<AudioClip> seClip = new List<AudioClip>();

    AudioSource aSource;

	// Use this for initialization
	void Start () {
        aSource = GetComponent<AudioSource>();
	}
	
	public void SEStart(SETitle sETitle)
    {
        aSource.PlayOneShot(seClip[(int)sETitle]);
    }
}
