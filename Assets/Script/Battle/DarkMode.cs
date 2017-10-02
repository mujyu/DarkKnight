using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class DarkMode : MonoBehaviour {
    
    public static bool darkModeIs = false;

    public static void DarkDamage()
    {
        //ダークモード時にHPを減らす
        if (darkModeIs == true)
        {
            Player.playerHP -= 3;
            if (Player.playerHP <= 0)
            {
                Player.playerHP = 0;
            }
        }
        else
        {
            if (Player.playerHP < 5000)Player.playerHP++;
        }
    }
}
