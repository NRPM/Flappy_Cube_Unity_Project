using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraPos;
    
  
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.cameraPos != null)
        Camera.main.transform.position = new Vector3(GameManager.instance.cameraPos.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z); 
    }
}
