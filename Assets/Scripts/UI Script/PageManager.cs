using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PageManager : MonoBehaviour
{
    public static void loadLevel()
    {
        SceneManager.LoadScene("Scenes/Level 1");
    }
}
