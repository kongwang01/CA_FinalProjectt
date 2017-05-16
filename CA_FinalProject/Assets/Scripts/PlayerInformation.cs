using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {
    static public int kill_number = 0;
    private string messageToShow; //用來儲存秀到螢幕上的字串
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    public bool IsDebug = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        Material newMat = Resources.Load("Red", typeof(Material)) as Material;
        this.GetComponent<Renderer>().material = newMat;
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
