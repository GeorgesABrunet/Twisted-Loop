using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
   public void PlayGame ()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       PlayerHealth.Lives = 3;
       DisplayStats.Lols = 0;
       PostGameStats.Jumps = 0;
       PostGameStats.Smacks = 0;
   }

   public void QuitGame ()
   {
       Debug.Log("You dun quit the game :(");
       Application.Quit();
   }
}