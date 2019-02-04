using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectionChar : MonoBehaviour {
    public Image[] p;
    public string[] control;
    public Sprite[] listChar;
	public Button start;
    private int[] current = new int[2];
	private int unlocked;
	private bool bonus;
	// Use this for initialization
	void Start () {
		unlocked = PlayerPrefs.GetInt ("Unlocked");
		bonus = true;
		PlayerPrefs.SetString("Player 1", "Learning/Mobil/ferrari");
        PlayerPrefs.SetString("Player 2", "Learning/Mobil/ferrari");
    }
	void Update () {
        mycontrol();
		if (bonus) 
		{
			if (current [0] != 5 && current[1] != 5) {
				start.interactable = true;
			} else {
				start.interactable = false;
			}	
		}

	}
    void mycontrol()
    {
        for(int i = 0; i<p.Length; i++)
        {
            if (Input.GetButtonDown(control[i])) { 
                float move = Input.GetAxisRaw(control[i]);
                if (move > 0)
                {
                    if (current[i] != listChar.Length-1)
                    {
                        current[i]++;
						if (bonus) {
							if (unlocked == 0) {
								if (current [i] == 4)
									current [i]++;
							} else {
								if (current [i] == 5)
									current [i] = 0;
							}
						}
                    }
                    else
                    {
                        current[i] = 0;
                    }
                    p[i].sprite = listChar[current[i]];
                }
                else
                {
                    //Kiri
                    if(current[i] != 0) { 
                        current[i]--;
						if (bonus) {
							if (unlocked == 0) {
								if (current [i] == 4)
									current [i]--;
							} else {
								if (current [i] == 5)
									current [i]--;
							}
						}
                    }
                    else
                    {
                        current[i] = listChar.Length - 1;
						if (bonus) {
							if (unlocked == 0) {
								if (current [i] == 4)
									current [i]--;
							} else {
								if (current [i] == 5)
									current [i]--;
							}
						}
                    }
                    p[i].sprite = listChar[current[i]];
                }
                PlayerPrefs.SetString("Player " + (i+1), "Learning/Mobil/"+p[i].sprite.name);
            }
        }
    }
}