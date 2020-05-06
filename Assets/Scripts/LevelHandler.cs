using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
    public void LoadNextLevel()
    {
        string currentSceneName = string.Empty;
        string nextSceneName = string.Empty;

        currentSceneName = SceneManager.GetActiveScene().name;

        switch(currentSceneName)
        {
            case "Title":
                nextSceneName = "Level_1";
                break;
            case "Level_1":
                nextSceneName = "Level_2";
                break;
            case "Level_2":
                nextSceneName = "Level_1";
                break;

        }

        if(!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.Log("Unknown transaction from scene " + currentSceneName);
        }
    }
}
