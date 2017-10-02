using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    Slider slider;

	// Use this for initialization
	void Start () {
        // スライダーを取得する
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }
	// Update is called once per frame
	void Update () {
        //slider.value = Enemy.hp;
	}
}
