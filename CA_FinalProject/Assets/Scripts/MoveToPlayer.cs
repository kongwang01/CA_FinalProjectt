using UnityEngine;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {
    GameObject player;
    public float speed = 0.01f;//移動速度
    private float firstSpeed;//紀錄第一次移動的距離

    int count = 0;

	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player");
        player = GameObject.FindGameObjectWithTag("Player");
        firstSpeed = Vector3.Distance(this.transform.position, player.transform.position) * speed;
	}
	
	// Update is called once per frame
	void Update () {
        /*Debug.Log(Time.deltaTime);
        //讓使用者每按一次 ↑ 時都移動一次，這只是為了方便看出每次移動的距離
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //先移動過後，再計算新的 speed
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed);
            speed = calculateNewSpeed();
        }*/

        if (speed == 0f)
            count++;
        if(count > 30)
            Destroy(this.gameObject);

        int rand_speed = Random.Range(8, 15); //隨機速度

        //先移動過後，再計算新的 speed
        this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed /(float)rand_speed);
        speed = calculateNewSpeed();
	}

    void FixedUpdate(){
        //先移動過後，再計算新的 speed
        //this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position, speed);
        //speed = calculateNewSpeed();

    }

    private float calculateNewSpeed()
    {
        //因為每次移動都是 Obj 在移動，所以要取得 Obj 和 player 的距離
        float tmp = Vector3.Distance(this.transform.position, player.transform.position);

        //當距離為0的時候，就代表已經移動到目的地了。
        if (tmp == 0)
            return tmp;
        else if (speed == 0f)
            return 0f;
        else
            return (firstSpeed / tmp);
    }

    //劍氣撞到怪物時，怪物消滅，並發出音效
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Slash" && (speed!=0f))
        {
            PlayerInformation.kill_number++;
            Debug.Log("hit");

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            this.transform.localScale = new Vector3(1f, 0.2f, 1f);
            speed = 0f;

            //Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
