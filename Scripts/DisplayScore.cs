using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayScore : MonoBehaviour
{
    public Text score;
    public int scroe;


    // Start is called before the first frame update
    void Start()
    {
        scroe = PlayerPrefs.GetInt("score");

    }

    // Update is called once per frame
    void Update()
    {
        scroe = PlayerPrefs.GetInt("score");
        score.text = string.Format("{0}", scroe);
    }
}
