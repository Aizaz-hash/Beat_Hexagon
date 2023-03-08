using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hexagon : MonoBehaviour
{
    public Rigidbody2D rb;
    public float shrinkSpeed = 0.05f;
    private static int counter = 0;




    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0, 360);
        transform.localScale = Vector3.one * 5f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.localScale -= shrinkSpeed * Time.deltaTime * Vector3.one;
        if (transform.localScale.x <= 0.30f)
        {
            Updatescore(true);
            Destroy(gameObject);
        }
    }


    //specific update in game (not after every frame)
    private void Updatescore(bool dec)
    {
        bool decision = dec;
        if (decision)
        {

            //score counter
            counter ++;
            PlayerPrefs.SetInt("score", counter);

            int highScore = PlayerPrefs.GetInt("HighScore");

            //If current score corsses highscore
            if (counter>highScore)
            {
                PlayerPrefs.SetInt("HighScore" , counter);
            }
            decision = false;
        }

    }

    //when game is over
    private void OnTriggerEnter2D(Collider2D collision)
    {
        counter = 0;
    }

}