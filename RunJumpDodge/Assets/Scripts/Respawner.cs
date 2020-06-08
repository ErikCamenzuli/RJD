using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //getting the players transform position and setting it to the 
        //transform position point for respawning.
        SceneManager.LoadScene("Menu");
    }

}
