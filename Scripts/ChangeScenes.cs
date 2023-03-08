using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScenes : MonoBehaviour
{

    //just for changing scenes
    public void MoveToScene(int SceneId)
    {

        SceneManager.LoadScene(SceneId); 
    }
}
