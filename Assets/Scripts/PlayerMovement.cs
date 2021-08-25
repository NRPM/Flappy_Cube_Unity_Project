using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerParent;
    public GameObject player;
    public GameObject brokenPlayer;
    private GameObject cameraPos;
    public float jumpForce;
    public float playerSpeed;
    private float delay;
    

    // Start is called before the first frame update
    void Start()
    {
        delay = 2f;
        playerParent.velocity = new Vector3(playerSpeed, 0, 0);
        cameraPos = playerParent.transform.GetChild(0).GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            playerParent.AddForce(new Vector3(0,jumpForce,0), ForceMode.VelocityChange);
        }
        if(player.transform.position.y <= -22 || player.transform.position.y >= 15)
        {
            DestroyPlayer();
        }
       
       
        
    }
    void DestroyPlayer()
    {
        GameManager.instance._state = GameManager.State.GAMEOVER;
        Destroy(gameObject);        
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.collider.CompareTag(Tags.OBSTACLE_TAG))
        {
            if(cameraPos != null)
            Destroy(playerParent.transform.GetChild(0).GetChild(0).gameObject);
            
            brokenPlayer.SetActive(true);
            player.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
          
         Invoke("DestroyPlayer", delay);
        }
    }

   
    
    }

