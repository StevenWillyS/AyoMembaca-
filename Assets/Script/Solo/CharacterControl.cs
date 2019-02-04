using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {
    public Finish end;
    public Transform[] pos;
    public float speed;
    public int score = 0;
    public QuizControl qc;
    public AudioSource effect;
    public AudioSource effectWrong;
    public string moveHori;
    public string moveShot;
    public bool enableInput = true;
    public Text text;
    public Text textScore;
    public Text timerText;
    private float timer = 5;
    private LineRenderer line;
    private int spot = 1;
    private bool stop = false;
    private int globaltarget;
    private float counter;
    private int health = 3;
    private float currentTime = 0;
    // Use this for initialization
    void Start()
    {
		timer = 5;
        Time.timeScale = 1;
        effect = GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enableInput)
        {
            countdown();
            move();
            shot();
        }
    }
    int check()
    {
        int target = 0;
        if (Input.GetButtonDown(moveHori))
        {
            float move = Input.GetAxisRaw(moveHori);
            if (move > 0)
            {
                //Kanan
                if (spot != 2)
                {
                    transform.Rotate(0, 0, -10);
                    target = 1;
                    stop = false;
                }
            }
            else
            {
                //Kiri
                if (spot != 0)
                {
                    transform.Rotate(0, 0, 10);
                    target = -1;
                    stop = false;
                }
            }
        }
        return target;
    }
    void move()
    {
        float test = speed * Time.deltaTime;
        int target = check();
        if (target != 0)
        {
            globaltarget = target;
        }
        if (!stop)
        {
            transform.position = Vector2.MoveTowards(transform.position, pos[spot + globaltarget].position, test);
            if (Vector2.Distance(transform.position, pos[spot + globaltarget].position) < 0.01)
            {
                spot += globaltarget;
                globaltarget = 0;
                transform.rotation = Quaternion.identity;
                stop = true;
            }
        }
    }
    void shot()
    {
        if (Input.GetButtonDown(moveShot) && counter == 0 && stop)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector3(transform.position.x, transform.position.y + 10, 0));
            if (spot == qc.jackpot)
            {
                effect.Play();
                qc.spawnQuiz();
                score += 10;
                textScore.text = score + "";
                currentTime = 0;
				timerUpdate ();
            }
            else
            {
                effectWrong.Play();
                health--;
                text.text = health+"";
                currentTime = 0;
                checkWin();
            }
        }
        if (Input.GetButtonUp(moveShot))
        {
            line.enabled = false;
        }
    }
    void checkWin()
    {
        if (health == 0)
        {
            end.finished();
        }
    }
    void countdown()
    {
		currentTime += Time.deltaTime;
		timerText.text = (int)(timer - currentTime) + "";
		if (currentTime > timer)
		{
			currentTime = 0;
			health--;
			text.text = health + "";
			qc.spawnQuiz();
			effectWrong.Play();
			checkWin();
		}
	}
	void timerUpdate()
	{
		if (score % 200 == 0 && timer!=2) {
			timer--;
		}	
	}
}
