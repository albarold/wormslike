using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class Mainmenu : MonoBehaviour
{

    public string level;
    public void StartButton()
    {
        SceneManager.LoadScene(level);
    }

    public void QuitButton()
    {
        EditorApplication.ExitPlaymode();
        Application.Quit();
    }

}
