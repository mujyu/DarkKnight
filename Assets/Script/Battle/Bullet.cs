using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 20;
    public static int power = 1;
    Spaceship spaceship = new Spaceship();

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;
	}
    void Update()
    {
        if (DarkMode.darkModeIs == false)
        {
            power = 1;
            speed = 8;
        }
        else if (DarkMode.darkModeIs == true)
        {
            power = 4;
            speed = 1;
        }
    }

}
