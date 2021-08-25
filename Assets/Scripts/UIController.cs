using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    
   public void GoToGameplay()
   {
       foreach(GameObject obstacle in GameManager.instance.instantiatedObstacles)
       Destroy(obstacle);
       GameManager.instance.score = 0;
       GameManager.instance.scoreText.text = "" + GameManager.instance.score;
       GameManager.instance._state = GameManager.State.GAMEPLAY;
   }
  

}
