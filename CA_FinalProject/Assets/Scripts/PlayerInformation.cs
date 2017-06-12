using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {
    static public int kill_number = 0;
    private string messageToShow; //用來儲存秀到螢幕上的字串
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    public bool IsDebug = false;

    Animator playerAnimator;
    static public bool clickOrNot = false;

	// Use this for initialization
	void Start () {
        playerAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
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
        if (other.tag == "Enemy")
        {
            //Material newMat = Resources.Load("Red", typeof(Material)) as Material;
            //this.GetComponent<Renderer>().material = newMat;
            Debug.Log("Game Over!");
            Application.LoadLevel(1);
        }
    }

    void OnGUI()
    {
        messageToShow = "kill: " + kill_number;
        //GUILayout.Label( messageToShow );
        guiStyle.fontSize = 36; //change the font size
        guiStyle.normal.textColor = Color.blue;
        GUILayout.Label(messageToShow, guiStyle);
    }
}
