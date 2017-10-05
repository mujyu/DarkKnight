using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeShot : MonoBehaviour {

    Player player = new Player();
    Spaceship spaceship;

    public void OnClick()
    {
        Player.shootingIs = false;
    }
    public void OnUp()
    { 
        Player.shootingIs = true;
    }
}
