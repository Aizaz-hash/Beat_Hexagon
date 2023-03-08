using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banner : MonoBehaviour
{
    public Text scores;
    public Text Highscores;

    int hs, s;
    // Start is called before the first frame update
    void Start()
    {
        s = PlayerPrefs.GetInt("score");
        hs = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        s = PlayerPrefs.GetInt("score");
        hs = PlayerPrefs.GetInt("HighScore");
        scores.text = string.Format("{0}", s);
        Highscores.text = string.Format("{0}", hs);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        scores.text = string.Format("{0}", 0);
        Highscores.text = string.Format("{0}", 0);
    }
}
