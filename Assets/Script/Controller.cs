using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    public Sprite[] mysprite;
    public AudioSource sound;
    public AudioSource word;
    public AudioClip[] voice;
    public AudioClip[] words;
    public Image ui;
    public Text abc;
    public Text desc;
    public string[] desk;
    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
    }
    public void changeUI(string target)
    {
        char letter = target[0];
        abc.text = target +" "+ target.ToLower();
        int i = letter-65;
        sound.clip = voice[i];
        word.clip = words[i];
        ui.sprite = mysprite[i];
        desc.text = desk[i];
    }
	public void playSound()
    {   
        sound.Play();
    }
    public void playWord()
    {
        word.Play();
    }
}
