/*using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour {
    public MovieTexture m;
	// Use this for initialization
	void Start () {
        //Handheld.PlayFullScreenMovie("CA_Bad_Ending_1.avi", Color.black, FullScreenMovieControlMode.Hidden);
        GetComponent<Renderer>().material.mainTexture = m;
        m.loop = false;
        m.Play();
        //GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
*/

/*
using UnityEngine;
using System.Collections;

public class PlayMovie : MonoBehaviour
{

void OnGUI()
{
// 播放影片, 按一下結束
if (GUI.Button (new Rect (20,10,200,50), "PLAY ControlMode.CancelOnTouch")) 
{
    Handheld.PlayFullScreenMovie("CA_Bad_Ending_1.avi", Color.black, FullScreenMovieControlMode.CancelOnInput);
}

// 播放影片, 並顯示面板(PLAY/PAUSE/進/退/BAR)
if (GUI.Button (new Rect (20,90,200,25), "PLAY ControlMode.Full")) 
{
    Handheld.PlayFullScreenMovie("CA_Bad_Ending_1.avi", Color.black, FullScreenMovieControlMode.Full);
}

// 播放影片, 不可中途停止, 播放完畢後自動關閉
if (GUI.Button (new Rect (20,170,200,25), "PLAY ControlMode.Hidden")) 
{
    Handheld.PlayFullScreenMovie("CA_Bad_Ending_1.avi", Color.black, FullScreenMovieControlMode.Hidden); 
}

// 播放影片, 並顯示面板
if (GUI.Button (new Rect (20,250,200,25), "PLAY ControlMode.Minimal")) 
{
    Handheld.PlayFullScreenMovie("CA_Bad_Ending_1.avi", Color.black, FullScreenMovieControlMode.Minimal);
}

}

}
*/


using UnityEngine;
using System.Collections;
public class PlayMovie : MonoBehaviour
{
    //影片紋理
    public MovieTexture movTexture;
    private AudioSource audio;

    void Start()
    {
        //設置是否循環撥放，這邊設定開頭撥放完就跳轉場景所以不需要Loop
        movTexture.loop = false;
        audio = GetComponent<AudioSource>();
        audio.clip = movTexture.audioClip;
        movTexture.Play();
        audio.Play();
    }
    void OnGUI()
    {
        //繪製紋理
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);
        if (GUILayout.Button("Restart!"))
        {
            //播放
            //if (!movTexture.isPlaying)
            //{
            //    movTexture.Play();
           // }
            //movTexture.Stop();
            Application.LoadLevel(0);
        }
       /* if (GUILayout.Button("Pause"))
        {
            //暫定
            movTexture.Pause();
        }
        if (GUILayout.Button("Stop"))
        {
            //停止
            movTexture.Stop();
        }*/
    }
}

/*
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(AudioSource))]

public class PlayMovie : MonoBehaviour
{
    public MovieTexture movie;
    private AudioSource audio;
    
    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        audio = GetComponent<AudioSource>();
        audio.clip = movie.audioClip;
        movie.Play();
        audio.Play();
    }

    
    void Update()
    {

    }
}*/