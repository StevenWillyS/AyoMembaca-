using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour {
    public GameObject finish;
    public GameObject pause;
    public Text message;
    public Text stat1;
    public Text stat2;
    public PlayerControl p1;
    public PlayerControl p2;
	public Image carWinner;
	public BGM soundControl;

    private PlayerControl temp;
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
	public void finished(PlayerControl player,Sprite sp)
    {
		soundControl.playClip2 ();
        Time.timeScale = 0;
        finish.SetActive(true);
        temp = player;
        message.text = player.name + "\nWaktu : " + player.time;
		carWinner.sprite = sp;
        p1.enableInput = false;
        p2.enableInput = false;
        showStatistic();
    }
    public void playAgain()
    {
        returnNormal();
        SceneManager.LoadScene("Duel");
    }
    public void mainMenu()
    {
        returnNormal();
        SceneManager.LoadScene("MainMenu");
    }
    public void paused()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        p1.enableInput = false;
        p2.enableInput = false;
		soundControl.pause ();
    }
    public void returnNormal()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
        p1.enableInput = true;
        p2.enableInput = true;
		soundControl.unpause ();
    }
    private void showStatistic()
    {
        stat1.text = "Player 1\nBenar : " + p1.correct +"\nSalah : "+p1.wrong;
        stat2.text = "Player 2\nBenar : " + p2.correct + "\nSalah : " + p2.wrong;
    }

}
