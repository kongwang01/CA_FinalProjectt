using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {
    static public int kill_number = 0;
    private string messageToShow; //用來儲存秀到螢幕上的字串
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    public bool IsDebug = false;

    Animator playerAnimator;
    static public bool clickOrNot = false;

    public AudioClip PlayerDie;

    bool GameOver = false;
    int dieCount = 0;

	// Use this for initialization
	void Start () {
        playerAnimator = gameObject.GetComponent<Animator>();
        kill_number = 0;
        dieCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (kill_number >= 100) //進入good end
            Application.LoadLevel(3);

        if (IsDebug && (kill_number >= 10))//Debug模式時，殺10隻就進入good end
            Application.LoadLevel(3);

        if (GameOver)
        {
            dieCount++;
            if ((dieCount % 5) == 0)
            {
                this.transform.Translate(0f, -0.05f, 0f, Space.World);
                this.transform.Rotate(new Vector3(1, 0, 0), 1.5f);
            }
        }

        if (dieCount >= 300)//進入bad end
        {
            Application.LoadLevel(1);
        }

        if (clickOrNot)
        {
            Debug.Log("click!");
            playerAnimator.SetBool("click", clickOrNot);
            clickOrNot = false;
        }
        //else
        //    playerAnimator.SetBool("click", false);


        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(1f, 0f, 0f, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(-1f, 0f, 0f, Space.World);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0f, 0f, -1f, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0f, 0f, 1f, Space.World);
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !GameOver)
        {
            //Material newMat = Resources.Load("Red", typeof(Material)) as Material;
            //this.GetComponent<Renderer>().material = newMat;
            Debug.Log("Game Over!");

            Destroy(GetComponent<Animator>());

            //播放人物死亡音效
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = PlayerDie;
            audio.Play();

            GameOver = true;
        }
    }

    void OnGUI()
    {
        if (GameOver)
        {
            messageToShow = "Game Over!";
            guiStyle.fontSize = 60;
            guiStyle.normal.textColor = Color.red;
        }
        else
        {
            messageToShow = "kill: " + kill_number;
            //GUILayout.Label( messageToShow );
            guiStyle.fontSize = 36; //change the font size
            guiStyle.normal.textColor = Color.blue;
        }
        GUILayout.Label(messageToShow, guiStyle);
    }
}
