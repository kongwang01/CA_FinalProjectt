using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {
    public GameObject player;
    public GameObject Enemy;

    public AudioClip EnemyDie;

	// Use this for initialization
	void Start () {
        //Enemy.gameObject.transform.localScale -= new Vector3(501, 501, 501);
        /*GameObject newEnemy = Instantiate(Enemy);
        newEnemy.gameObject.transform.localScale += new Vector3(149, 149, 149);
        newEnemy.transform.Translate(5, 0, 5);
        newEnemy.AddComponent<MoveToPlayer>();*/

        //GameObject objState = GameObject.Find("MoveToPlayer");
        //newEnemy.AddComponent(Type.GetType("MoveToPlayer"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate(){
        int rand_x = Random.Range(20, 50); //怪物的初始位置隨機
        int rand_z = Random.Range(20, 50);

        if ((rand_x % 2) == 0)
            rand_x = -rand_x;

        if ((rand_z % 2) == 0)
            rand_z = -rand_z;

        GameObject newEnemy = Instantiate(Enemy);
        //newEnemy.gameObject.transform.localScale += new Vector3(149, 149, 149);
        newEnemy.transform.Translate(rand_x, 0, rand_z);
        //newEnemy.transform.rotation = Quaternion.Euler(0.0F, (float)rand_z - player.transform.position.z, 0.0F);
        //newEnemy.transform.rotation = Quaternion.Euler(newEnemy.transform.position - player.transform.position);

        //讓怪物面向玩家
        //Vector3 relativePos = newEnemy.transform.position - player.transform.position;
        Vector3 relativePos = player.transform.position - newEnemy.transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        newEnemy.transform.rotation = rotation;

        newEnemy.AddComponent<MoveToPlayer>();
        newEnemy.tag = "Enemy";

        AudioSource audioSource = newEnemy.AddComponent<AudioSource>();
        audioSource.clip = EnemyDie;
    }
}
