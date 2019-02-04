using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControl : MonoBehaviour {
    public GameObject setting;
    public GameObject play;
    public GameObject learn;
    public GameObject selection;
    public GameObject loadingScreen;
	public GameObject train;
	public GameObject tutorialTr;
	public GameObject tutorialPl;
	public GameObject credit;
    public Button settingButton;
    public Button playButton;
    public Slider sound;
    public Slider effect;
    public Slider loading;
	public AudioSource source;
	public MaskotAnimationControl maskot;
    // Use this for initialization
    void Start () {
        sound.value = PlayerPrefs.GetFloat("SoundVol");
        effect.value = PlayerPrefs.GetFloat("EffectVol");
		source = GetComponent<AudioSource> ();
    }
    public void open(int code)
    {
		source.Play ();
        switch (code)
        {
            case 0:
                learn.SetActive(true);
                break;
			case 1:
				train.SetActive (true);
	            break;
            case 2:
                play.SetActive(true);
                break;
            case 3:
                setting.SetActive(true);
                break;
            case 4:
                Application.Quit();
                break;
			case 5:
				maskot.playTalk (2);
                StartCoroutine(loadLevel("Solo"));
                //SceneManager.LoadScene("Solo");
                break;
            case 6:
				maskot.playTalk (2);
				StartCoroutine(loadLevel("Duel"));
                //SceneManager.LoadScene("Duel");
                break;
            case 7:
				maskot.playTalk (1);
				StartCoroutine(loadLevel("Learning"));
                //SceneManager.LoadScene("Learning");
                break;
			case 8:
				maskot.playTalk (1);
                StartCoroutine(loadLevel("Learning 2"));
                //SceneManager.LoadScene("Learning 2");
                break;
            case 9:
                selection.SetActive(true);
                play.SetActive(false);
                break;
			case 10:
				maskot.playTalk (1);
				StartCoroutine(loadLevel("Solve"));
				break;
			case 11:
				maskot.playTalk (1);
				StartCoroutine(loadLevel("Solve 2"));
				break;
			case 12:
				tutorialTr.SetActive (true);
				break;
			case 13:
				tutorialPl.SetActive (true);
				break;
			case 14:
				credit.SetActive (true);
				break;
        }

    }
    public void closePanel(int code)
    {
		source.Play ();
        switch (code)
        {
            case 0:
                learn.SetActive(false);
                break;
			case 1:
				train.SetActive(false);
				break;
            case 2:
                play.SetActive(false);
                break;
            case 3:
                setting.SetActive(false);
                break;
            case 9:
                selection.SetActive(false);
                break;
			case 12:
				tutorialTr.SetActive (false);
				break;
			case 13:
				tutorialPl.SetActive (false);
				break;
			case 14:
				credit.SetActive (false);
				break;
        }
    }
    IEnumerator loadLevel(string name)
    {
        AsyncOperation opr = SceneManager.LoadSceneAsync(name);
        loadingScreen.SetActive(true);
        while (!opr.isDone)
        {
            float progress = Mathf.Clamp01(opr.progress / .9f);
            loading.value = progress;
            yield return null;
        }
    }
}
