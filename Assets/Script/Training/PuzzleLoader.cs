using UnityEngine;
using UnityEngine.UI;

public class PuzzleLoader : MonoBehaviour {
    public PuzzleQuestion testPuzzle;
    public Text problem;
    public Text status;
	public Text numberText;
	public Text correctText;
	public Text wrongText;
    public Text[] Answer;
    public Image pict;
    public GameObject next;
    public GameObject closed;
	public GameObject finish;
	public int number;
	public SoundPlayer sp;
    private PuzzleCollection allPuzzle;
	private int chance = 2;
	private int question = 10;
	private int correct = 0;
    // Use this for initialization
    void Start () {
		number = 0;
		correct = 0;
        allPuzzle = new PuzzleCollection();
        allPuzzle.init();
        rollPuzzle();
	}
    private void rollPuzzle()
    {
        testPuzzle = allPuzzle.GetQuestion();
        preparePuzzle();
        prepareAnswer();
		number++;
		numberText.text = ""+(number);
    }
    private void prepareImg()
    {
        Sprite sp = Resources.Load<Sprite>(testPuzzle.img);
        pict.sprite = sp;
    }
    private void preparePuzzle()
    {
        prepareImg();
        testPuzzle.asked = true;
        string missing = testPuzzle.missingWord;
        string replace = "";
        for (int i = 0; i<missing.Length/2; i++)
        {
            replace += "_ ";
        }
        string outWord = testPuzzle.word.Replace(missing, replace);
        problem.text = outWord;
    }
    private int getAnswer()
    {
        int answer = 0;
        for(int i = 0; i<testPuzzle.answer.Length; i++)
        {
            if (testPuzzle.answer[i].Equals(testPuzzle.missingWord))
            {
                answer = i;
                break;
            }
        }
        return answer;
    }
    private void prepareAnswer()
    {
        for(int i = 0; i< testPuzzle.answer.Length; i++)
        {
            Answer[i].text = testPuzzle.answer[i];
        }
    }
    public void selectAnswer(int index)
    {
        if(index == getAnswer())
        {
			sp.playRight();
            status.text = "<color=#0000ffff>Benar!</color>";
            closed.SetActive(true);
            next.SetActive(true);
            problem.text = testPuzzle.word;
			correct++;
			chance = 2;
        }
        else
        {
			sp.playWrong();
            status.text = "<color=#ff0000ff>Salah!</color>";
			chance--;
			if (chance == 0) 
			{
				closed.SetActive(true);
				next.SetActive(true);
				problem.text = testPuzzle.word;
				chance = 2;	
			}
        }
		if (number == question) 
		{
			finish.SetActive (true);
			correctText.text = "" + correct;
			wrongText.text = "" + (question - correct);
		}
    }
    public void nextPuzzle()
    {
        closed.SetActive(false);
        status.text = "";
        rollPuzzle();
        next.SetActive(false);
    }
	public void reset()
	{
		number = 0;
		correct = 0;
		chance = 2;
		finish.SetActive (false);
		nextPuzzle ();
	}
}
