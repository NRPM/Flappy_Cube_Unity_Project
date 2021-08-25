using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject[] instiantedObstacles;
    public GameObject obstaclePrefab;
    private GameObject currentObstacle;
    public GameObject scorePanel, menuPanel,gameOverPanel;
    public GameObject playerParent;
    public List<GameObject> instantiatedObstacles = new List<GameObject>();
    [HideInInspector]
    public GameObject instantiatedPlayer;
    private Transform playerTransform;
    private Transform _endPoint;
    public Transform cameraPos;
    public Text scoreText;
    public Text highScoreText;
    public Text highScoreText1;
    public int score;
    public enum State{MENU, GAMEPLAY, GAMEOVER};
    public State _state;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        

        _state = State.MENU;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_state)
        {
            case State.MENU:
                menuPanel.SetActive(true);
                scorePanel.SetActive(false);
                highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");

                break;
            
            case State.GAMEPLAY:
                
                menuPanel.SetActive(false);
                scorePanel.SetActive(true);
                gameOverPanel.SetActive(false);
                if(currentObstacle == null)
                {
                 currentObstacle = Instantiate(obstaclePrefab);
                 instantiatedObstacles.Add(currentObstacle);
                }
                if(instantiatedPlayer == null)
                instantiatedPlayer = Instantiate(playerParent);
                if(playerTransform == null)
                {
                    playerTransform = instantiatedPlayer.transform.GetChild(0);
                    cameraPos = instantiatedPlayer.transform.GetChild(0).GetChild(0);
                }
                else
                {
                    _endPoint = currentObstacle.transform.GetChild(0);
                     SpawnObstacle();
                }
                break;

            case State.GAMEOVER:
                gameOverPanel.SetActive(true);
                if(score > PlayerPrefs.GetInt("highscore"))
                PlayerPrefs.SetInt("highscore", score);
                highScoreText1.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
                break;
                

        }
    }

    void SpawnObstacle()
    {
        if(Vector3.Distance(playerTransform.transform.position, _endPoint.position) <= 7.5)
        {
            currentObstacle = Instantiate(obstaclePrefab, new Vector3(_endPoint.position.x, Random.Range(-5f, 3f),_endPoint.position.z), Quaternion.identity);
            instantiatedObstacles.Add(currentObstacle);
        }
    }
}
