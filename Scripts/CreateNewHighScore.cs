using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewHighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public void createHighscore()
    {
      
        PlayerPrefs.SetInt("score", 0);
        //PlayerPrefs.SetInt("HighScore", 0);

    }



    // Update is called once per frame

}
