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
        }
        else if (DarkMode.darkModeIs == true)
        {
            if (Player.playerHP != 5000)
            {
                power = (Player.jikiHP - Player.playerHP) / 500 + 3;
            }else if(Player.playerHP == 5000)
            {
                power = 3;
            }
            if (Player.playerHP <= 0)
            {
                power = 20;
            }
        }
    }
    
}
