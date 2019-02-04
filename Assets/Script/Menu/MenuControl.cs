using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuControl : MonoBehaviour {
    public GameObject pause;
	public BGM soundControl;
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (pause.activeSelf) {
				cancel ();
			} else {
				confirmation ();
			}
		}	
	}
	public void backToMain()
	{
		soundControl.unpause ();
        SceneManager.LoadScene("MainMenu");
    }
    public void confirmation()
    {
        pause.SetActive(true);
		soundControl.pause ();
    }
    public void cancel()
    {
        pause.SetActive(false);
		soundControl.unpause ();
    }
    
}
