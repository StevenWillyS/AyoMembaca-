using UnityEngine;
using UnityEngine.UI;

public class QuizControl : MonoBehaviour {
    public Image[] slot;
    public Text hint;
    public int jackpot;
    private PuzzleCollection allPuzzle;
    private PuzzleQuestion[] myPuzzle = new PuzzleQuestion[3];
    // Use this for initialization
    void Start () {
        allPuzzle = new PuzzleCollection();
        allPuzzle.init();
        spawnQuiz();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void spawnQuiz()
    {
        myPuzzle = allPuzzle.GetRandom3();
        jackpot = Random.Range(0, 3);
        hint.text = myPuzzle[0].word;
        if (jackpot == 0)
        {
            Sprite sp = Resources.Load<Sprite>(myPuzzle[0].img);
            slot[0].sprite = sp;
            Sprite sp1 = Resources.Load<Sprite>(myPuzzle[1].img);
            slot[1].sprite = sp1;
            Sprite sp2 = Resources.Load<Sprite>(myPuzzle[2].img);
            slot[2].sprite = sp2;
        }
        else if (jackpot == 1)
        {
            Sprite sp = Resources.Load<Sprite>(myPuzzle[0].img);
            slot[1].sprite = sp;
            Sprite sp1 = Resources.Load<Sprite>(myPuzzle[1].img);
            slot[0].sprite = sp1;
            Sprite sp2 = Resources.Load<Sprite>(myPuzzle[2].img);
            slot[2].sprite = sp2;
        }
        else if (jackpot == 2)
        {
            Sprite sp = Resources.Load<Sprite>(myPuzzle[0].img);
            slot[2].sprite = sp;
            Sprite sp1 = Resources.Load<Sprite>(myPuzzle[1].img);
            slot[0].sprite = sp1;
            Sprite sp2 = Resources.Load<Sprite>(myPuzzle[2].img);
            slot[1].sprite = sp2;
        }
    }
}
