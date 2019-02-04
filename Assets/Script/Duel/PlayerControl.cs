using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public EndGameControl endgame;
    public Transform[] pos;
    public Transform car;
    public SpriteRenderer mycar;
    public float speed;
    public QuizControl qc;
    public AudioSource effect;
    public AudioSource effectWrong;
    public string moveHori;
    public string moveShot;
    public float defaultSpeed = 0.4f; //0.2f slow
    public bool enableInput = true;
    public string name;
    public int correct = 0;
    public int wrong = 0;
    public float time;
    private LineRenderer line;
    private float speedCar;
    private int spot = 1;
    private bool stop = false;
    private int globaltarget;
    private float counter;
	private float upspeed,downspeed;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        speedCar = defaultSpeed;
        effect = GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
        Sprite sp = Resources.Load<Sprite>(PlayerPrefs.GetString(name));
        mycar.sprite = sp;
		upspeed = 0.025f;
		downspeed = upspeed*3;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (enableInput) { 
            move();
            shot();
        }
        MoveCar();
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
                    transform.Rotate(0, 0, -15);
                    target = 1;
                    stop = false;
                }
            }
            else
            {
                //Kiri
                if (spot != 0)
                {
                    transform.Rotate(0, 0, 15);
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
        if (Input.GetButtonDown(moveShot) && stop)
        {
            line.enabled = true;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, new Vector3(transform.position.x, transform.position.y+10, 0));
            if (spot == qc.jackpot)
            {
                effect.Play();
                qc.spawnQuiz();
				speedCar += upspeed;
                correct++;
            }
            else
            {
				speedCar -= downspeed;
                effectWrong.Play();
                wrong++;
            }
        }
        if (Input.GetButtonUp(moveShot))
        {
            line.enabled = false;
        }
    }
    void MoveCar()
    {
        if(speedCar != defaultSpeed)
        {
            counter += Time.deltaTime;
            if (counter > 2)
            {
                counter = 0;
                if (speedCar > defaultSpeed)
                {
					speedCar -= upspeed;
                }
                else
                {
					speedCar += downspeed;
                }
            }
        }
        car.position += Vector3.right* speedCar * Time.deltaTime;
        checkWin();
    }
    void checkWin()
    {
		if (Camera.main.WorldToScreenPoint(car.position).x > Screen.width - 80 && Time.timeScale!=0)
        {
			endgame.finished(this,mycar.sprite);
        }
    }
}
