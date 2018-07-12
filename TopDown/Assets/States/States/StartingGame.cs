using UnityEngine;
using UnityEngine.UI;
namespace GameStates { 
    public class StartingGame : AbstractGameObjectStates {
        //private InputField name;
        private GameObject enteringMenu;
        //string playerName;
        bool startGame;
        GameObject effects;
        private GameManager gameManager;

	    // Use this for initialization
	    public StartingGame(MonoBehaviour parent):base(parent)
        {
            gameManager = (GameManager)parent;
            enteringMenu = gameManager.enteringMenu;
            startGame = gameManager.startGame;
            effects = gameManager.audioManager;
            effects.SetActive(false);
            Time.timeScale = 0f;
        }
	
	    // Update is called once per frame
	    public override void  Update () {
            startGame = gameManager.startGame;
            if(startGame)
            {
                Time.timeScale = 1f;
                effects.SetActive(true);
                enteringMenu.SetActive(false);
                gameManager.currentState = new GameStates.Playing(gameManager);
            }
	    }
    }
}