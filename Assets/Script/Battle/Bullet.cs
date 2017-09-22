using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 20;
    public static int power = 1;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}

}
