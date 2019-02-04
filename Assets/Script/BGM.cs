using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class BGM : MonoBehaviour {
	public AudioSource source;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioMixerSnapshot paused;
	public AudioMixerSnapshot unpaused;
	public Image sound;
	void Awake(){
		source.clip = clip1;
		source.Play ();
	}
	public void playClip2()
	{
		source.clip = clip2;
		source.Play ();	
	}
	public void pauseBGM(){
		if (source.isPlaying == true) {
			source.Pause ();
			sound.color = Color.black;
		} else {
			source.UnPause ();
			sound.color = Color.white;
		}
	}
	public void pause(){
		paused.TransitionTo (.01f);
	}
	public void unpause(){
		unpaused.TransitionTo (.01f);
	}
}
