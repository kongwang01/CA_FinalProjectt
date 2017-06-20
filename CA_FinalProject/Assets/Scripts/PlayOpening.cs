using UnityEngine;
using System.Collections;
public class PlayOpening : MonoBehaviour
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

    void Update()
    {
        if (!movTexture.isPlaying) //當影片結束，就開始遊戲
            Application.LoadLevel(0);
    }

    void OnGUI()
    {
        //繪製紋理
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);
        if (GUILayout.Button("Skip"))
        {
            Application.LoadLevel(0);
        }

    }
}