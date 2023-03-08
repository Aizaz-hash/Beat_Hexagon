using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayHighScore : MonoBehaviour
{
    public Text highscore;
    public int highScroe;


    // Start is called before the first frame update
    void Start()
    {
        highScroe = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
       highScroe = PlayerPrefs.GetInt("HighScore");
       highscore.text = string.Format("{0}", highScroe);
    }
}
