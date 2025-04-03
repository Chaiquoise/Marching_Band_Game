using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTitle : MonoBehaviour

{
    public void LoadNextScene()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}

