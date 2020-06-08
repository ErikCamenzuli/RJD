using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //setting pause to false
    public static bool isPaused = false;
    //refencing gameobject to the menu
    public GameObject menu;

 /// <summary>
 /// checking if the escape key has been pressed
 /// if it has then either call "ContinueGame()" or "PausedGame()"
 /// </summary>
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
    //quits game
    public void QuitCurrentGame()
    {
        SceneManager.LoadScene("Menu");
    }
    //continues game
    public void ContinueGame()
    {
        //sets menu to be inactive
        menu.SetActive(false);
        //sets the time back to normal speed
        Time.timeScale = 1f;
        //setting pause to false
        isPaused = false;            
    }
    //pause game
    public void PausedGamme()
    {
        //sets to true if menu is activate
        menu.SetActive(true);
        //sets the time to 0
        Time.timeScale = 0f;
        //setting pause to true
        isPaused = true;
    }

}
