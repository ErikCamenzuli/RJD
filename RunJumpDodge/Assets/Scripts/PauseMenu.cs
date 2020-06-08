using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ContinueGame();
            }
            else
            {
                PausedGamme();
            }
        }
    }

    public void QuitCurrentGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ContinueGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;            
    }

    public void PausedGamme()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
