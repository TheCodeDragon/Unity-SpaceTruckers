using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {
//Utility menu management script//
    public void ExitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LevelLoader(string LevelToLoad)
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
