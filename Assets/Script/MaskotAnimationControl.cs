using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskotAnimationControl : MonoBehaviour {
	public Animator anim;
	public string[] text;
	public GameObject bubble;
	public float delay = 0.1f;
	private string currentText = "";
	public void playTalk(int index = 0)
	{
		anim.SetBool ("talk", true);
		showBubble (index);
	}
	public void playIdle()
	{
		anim.SetBool ("talk", false);
		hideBubble ();
	}
	private void showBubble(int index = 0)
	{
		StartCoroutine (showText (index));
		bubble.SetActive (true);
	}
	private void hideBubble()
	{
		bubble.SetActive (false);
	}
	IEnumerator showText(int index = 0)
	{
		Text bubbleText = bubble.GetComponentInChildren<Text> ();
		for (int i = 0; i <= text [index].Length; i++) 
		{
			currentText = text [index].Substring (0, i);
			bubbleText.text = currentText;
			yield return new WaitForSeconds (delay);
		}
	}
}
