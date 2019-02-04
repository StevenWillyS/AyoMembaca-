using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverControl : MonoBehaviour {
	public Text[] answer;
	public void changeColor(int index)
	{
		answer [index].color = Color.blue;
	}
	public void returnColor(int index)
	{
		answer [index].color = Color.white;
	}
}
