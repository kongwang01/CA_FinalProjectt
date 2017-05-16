using UnityEngine;
using System.Collections;

public class CreateEnemy : MonoBehaviour {
    public GameObject player;
    public GameObject Enemy;

	// Use this for initialization
	void Start () {
        //Enemy.gameObject.transform.localScale -= new Vector3(501, 501, 501);
        GameObject newEnemy = Instantiate(Enemy);
        newEnemy.transform.Translate(5, 0, 5);

        //GameObject objState = GameObject.Find("MoveToPlayer");
        //newEnemy.AddComponent(Type.GetType("MoveToPlayer"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
