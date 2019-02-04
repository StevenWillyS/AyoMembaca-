using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject finish;
    public GameObject pause;
	public GameObject[] star;
	public Text message;
	public BGM soundControl;
    public CharacterControl temp;
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (pause.activeSelf) {
				returnNormal ();
			} else {
				paused ();
			}
		}	
	}
    public void finished()
    {
        Time.timeScale = 0;
        finish.SetActive(true);
		if (PlayerPrefs.GetInt ("Highscore") >= temp.score) {
			message.text = "Highscore: "+PlayerPrefs.GetInt("Highscore") +"\nScore Anda: " + temp.score;
		} else {
			message.text = "New Highscore!\nScore Anda: " + temp.score;
			PlayerPrefs.SetInt ("Highscore", temp.score);
		}
        temp.enableInput = false;
		starSet ();
    }
    public void playAgain()
    {
        returnNormal();
        SceneManager.LoadScene("Solo");
    }
    public void mainMenu()
    {
        returnNormal();
        SceneManager.LoadScene("MainMenu");
    }
    public void paused()
    {
		soundControl.pause ();
        Time.timeScale = 0;
        pause.SetActive(true);
        temp.enableInput = false;
    }
    public void returnNormal()
	{
		soundControl.unpause ();
        Time.timeScale = 1;
        pause.SetActive(false);
        temp.enableInput = true;
		star [0].SetActive (false);
		star [1].SetActive (false);
		star [2].SetActive (false);		
    }
	private void starSet()
	{
		if (temp.score > 1000) {
			star [0].SetActive (true);
			star [1].SetActive (true);
			star [2].SetActive (true);	
			message.text+="\nSelamat Bintang Penuh!";
			PlayerPrefs.SetInt ("Unlocked", 1);
		} else if (temp.score > 500) {
			star [0].SetActive (true);
			star [1].SetActive (true);
		} else if(temp.score >100) {
			star [0].SetActive (true);
		}
	}
}
