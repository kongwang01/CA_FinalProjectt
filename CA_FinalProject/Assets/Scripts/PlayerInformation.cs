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
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Material newMat = Resources.Load("Red", typeof(Material)) as Material;
            //this.GetComponent<Renderer>().material = newMat;
            Debug.Log("Game Over!");
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
