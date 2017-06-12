using UnityEngine;
using System.Collections;

public class ClickDetection : MonoBehaviour {
    public GameObject slash;
    public Camera curr_camera;

    GameObject objIsHit;
    //private bool IsHit = false;
    private Vector3 screenPoint;
    private Vector3 offset;

    int speed;
    float friction;
    float lerpSpeed;
    private float xDeg;
    private float yDeg;
    private Quaternion fromRotation;
    private Quaternion toRotation;

    Vector3 startDragDir;
    Vector3 currentDragDir;
    Quaternion initialRotation;
    float angleFromStart;

    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //int layerMask = LayerMaskNo.DEFAULT;
        int layerMask = -1;
        float maxDistance = 10;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);


        if (Input.GetMouseButtonDown(0) && hit.collider)
        {
            //Debug.Log ("mouse :" +Input.mousePosition + " , ray :" + (Vector2)ray.origin + " , D :" + (Vector2)ray.direction);
            IsHit = true; //表示有用左鍵點擊到物件
            objIsHit = hit.collider.gameObject; //紀錄點擊到哪個物件
            Debug.Log(hit.collider.gameObject.name);

            if (objIsHit.tag == "Enemy") //點擊到敵人就消滅
                Destroy(objIsHit);
        }*/ 
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = curr_camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            //Debug.DrawLine(Camera.main.transform.position, hit.transform.position, Color.red, 0.1f, true);
            //Debug.Log(hit.transform.name);

            objIsHit = hit.collider.gameObject; //紀錄點擊到哪個物件

            if (objIsHit.tag == "Enemy") //點擊到敵人就消滅
            {

                PlayerInformation.clickOrNot = true;

                //PlayerInformation.kill_number++;
                //Destroy(objIsHit);

                //讓玩家播放攻擊動畫

                GameObject newSlash = Instantiate(slash);
                newSlash.transform.Translate(player.transform.position.x, player.transform.position.y, player.transform.position.z);

                //揮劍音效
                AudioSource player_audio = player.GetComponent<AudioSource>();
                player_audio.Play();

                //讓玩家朝向怪物
                Vector3 relativePos = objIsHit.transform.position - player.transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos);
                player.transform.rotation = rotation;


                //讓劍氣朝向怪物
                //Vector3 relativePos = newEnemy.transform.position - player.transform.position;
                relativePos = objIsHit.transform.position - newSlash.transform.position;
                rotation = Quaternion.LookRotation(relativePos);
                newSlash.transform.rotation = rotation;

                newSlash.AddComponent<SlashToEnemy>();
                newSlash.GetComponent<SlashToEnemy>().enemy = objIsHit;
                newSlash.tag = "Slash";
            }
        }
        

    }
}
