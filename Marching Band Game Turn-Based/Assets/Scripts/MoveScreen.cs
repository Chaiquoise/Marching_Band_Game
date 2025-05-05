using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveScreen : MonoBehaviour
{

    public string sceneName = "SampleScene";

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
