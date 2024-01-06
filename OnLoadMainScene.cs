using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnLoadMainScene : MonoBehaviour
{

    public void StartScene(string MainGame)
    {
    SceneManager.LoadScene(MainGame);
    }
}
