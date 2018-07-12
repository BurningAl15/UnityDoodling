using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
    //Player
    public GameObject player;
    //player Health
    public Image healthUI;
    public Text healthText;

    //Map Randomizer
    public GameObject MapRandomizer;
    //Music Animator
    public GameObject music;

    //FPS
    public float fps = 0.0f;
    public Text fpsChecker;

    //Check Quantity of enemies
    public Text enemyChecker;

    //Start Game
    public bool startGame;
    [SerializeField]
    float delay;

    //
    public GameObject enteringMenu;

    public IGameObjectState currentState;
    public GameObject audioManager;
    static public GameManager GameInstance
    {
        get;
        private set;
    }

    private void Awake()
    {
        //FPS
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

    }

    // Use this for initialization
    void Start () {
        GameInstance = this;
        currentState = new GameStates.StartingGame(this);
        startGame = false;
	}

    // Update is called once per frame
    void Update () {
        #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        #endif
        currentState.Update();
        Debug.Log(startGame);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    private void LateUpdate()
    {
        currentState.LateUpdate();
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void Coroutine()
    {
        StartCoroutine("Death");
    }

    IEnumerator Death()
    {
        player.GetComponent<TopDownPlayer>().Animation();
        player.GetComponent<TopDownPlayer>().enabled = false;
        
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
