using UnityEngine;
using System.Collections;

public class ClickDetection : MonoBehaviour {

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

    // Use this for initialization
    void Start()
    {

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
                PlayerInformation.kill_number++;
                Destroy(objIsHit);
            }
        }
        

    }
}
