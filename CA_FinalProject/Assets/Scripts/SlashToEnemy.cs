using UnityEngine;
using System.Collections;

public class SlashToEnemy : MonoBehaviour {
    public GameObject enemy;
    public float speed = 0.1f;//移動速度
//    private float firstSpeed;//紀錄第一次移動的距離

    // Use this for initialization
    void Start()
    {
        //player = GameObject.Find("Player");

//        firstSpeed = Vector3.Distance(this.transform.position, enemy.transform.position) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(Time.deltaTime);
        //讓使用者每按一次 ↑ 時都移動一次，這只是為了方便看出每次移動的距離
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //先移動過後，再計算新的 speed
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed);
            speed = calculateNewSpeed();
        }*/

        //if (speed <= 0.2f)
        //    Destroy(this.gameObject);

        //先移動過後，再計算新的 speed
        if ((this.gameObject != null) && (enemy.gameObject != null))
        {
            this.transform.position = Vector3.Lerp(this.transform.position, enemy.transform.position, speed / 0.5f);
//            speed = calculateNewSpeed();
        }
        else
            Destroy(this.gameObject);
    }

    void FixedUpdate()
    {
        //先移動過後，再計算新的 speed
        //this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed);
        //speed = calculateNewSpeed();

    }

//    private float calculateNewSpeed()
//    {
        //因為每次移動都是 Obj 在移動，所以要取得 Obj 和 player 的距離
//        float tmp = Vector3.Distance(this.transform.position, enemy.transform.position);

        //當距離為0的時候，就代表已經移動到目的地了。
//        if (tmp == 0)
//            return tmp;
//        else
//            return (firstSpeed / tmp);
//    }

}
