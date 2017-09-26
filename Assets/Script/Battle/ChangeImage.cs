using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{

    public Sprite _true;
    public Sprite _false;
    //private bool flg = true;

    public void changeImage()
    {
        var img = GetComponent<Image>();
        img.sprite = (DarkMode.darkModeIs) ? _true : _false;
        if (DarkMode.darkModeIs == true)
        {
            DarkMode.darkModeIs = false;
        }
        else
        {
            DarkMode.darkModeIs = true;
        }
        Debug.Log(DarkMode.darkModeIs);
    }
}