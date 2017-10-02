using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBullet : MonoBehaviour {

    SpriteRenderer sr;
    public Sprite idleSprite;//基本画像
    public Sprite darkModeSprite;//変更後の画像

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (DarkMode.darkModeIs == true)
        {
            sr.sprite = darkModeSprite;
        }
        else
        {
            sr.sprite = idleSprite;
        }
    }
}
