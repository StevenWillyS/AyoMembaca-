using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {
	public AudioClip right;
	public AudioClip wrong;
	public AudioSource source;
	public void playRight()
	{
		source.clip = right;
		source.Play ();
	}
	public void playWrong()
	{
		source.clip = wrong;
		source.Play ();
	}
}
