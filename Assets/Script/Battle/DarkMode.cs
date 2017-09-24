using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class DarkMode : MonoBehaviour {
    
    public static bool darkModeIs = false;

	public void OnClick()
    {
        if (darkModeIs == false) darkModeIs = true;
        else if (darkModeIs == true) darkModeIs = false;
    }

}
