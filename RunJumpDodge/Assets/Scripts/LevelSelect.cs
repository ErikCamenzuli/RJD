using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    /// <summary>
    /// allowing to set the level selection in the inspector
    /// </summary>
    /// <param name="level"></param>
    public void SelectLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    /// <summary>
    /// quits game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
