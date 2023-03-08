using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 600f;
    float movement = 0f;
    int highScroe = 0;
    int score = 0;
    // Update is called once per frame


    void Update()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            movement = SimpleInput.GetAxis("Horizontal");
            score = PlayerPrefs.GetInt("score");
            highScroe = PlayerPrefs.GetInt("HighScore");
        }
        else if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            movement = Input.GetAxisRaw("Horizontal");
            //movement = SimpleInput.GetAxis("Horizontal");
            score = PlayerPrefs.GetInt("score");
            highScroe = PlayerPrefs.GetInt("HighScore");
            Debug.Log(highScroe + "HS");
            Debug.Log(score + "S");
        }

    }
    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, movement * Time.fixedDeltaTime * -moveSpeed);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        score = PlayerPrefs.GetInt("score");
        highScroe = PlayerPrefs.GetInt("HighScore");

        if (score >= highScroe)
        {
            PlayFabManager obj = new PlayFabManager();
            obj.setScore(highScroe);
            SceneManager.LoadScene(2);
        }
        else if (score < highScroe || score == 0 )
        {
            SceneManager.LoadScene(3);
        }
    }
}