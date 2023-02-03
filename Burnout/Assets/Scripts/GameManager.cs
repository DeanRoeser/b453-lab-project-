using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    bool gameEnd = false;

   public bool restart = false;

    void Awake()
    {
        Instance = this;
    }

   public void EndGame()
    {
           if (gameEnd == false)
           {
               gameEnd = true;
               Debug.Log("GAME OVER\n" + "Press 'q' to restart");
                
                //if (Input.GetKey("q"))
                //{
                   // Debug.Log("t");
                    Restart();
               // }
               
           }
    }
   
   void Restart()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
