using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string MainScene;
    public void StartGame(){
        SceneManager.LoadScene(MainScene);
    }
    public void QuitGame(){
        Application.Quit();
    }
}
