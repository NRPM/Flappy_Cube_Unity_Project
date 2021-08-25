using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider trigger)
    {
        if(trigger.CompareTag(Tags.PLAYER_TAG))
        {
            GameManager.instance.score++;
            GameManager.instance.scoreText.text = "" + GameManager.instance.score;
        }
    }

    
}
