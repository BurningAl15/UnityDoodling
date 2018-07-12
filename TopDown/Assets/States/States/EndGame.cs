using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace GameStates
{
    public class EndGame : AbstractGameObjectStates
    {
        private GameManager gameManager;
        bool startGame;
        GameObject player;
        GameObject music;
        float fps;
        Text fpsChecker;
        Image healthUI;
        Text healthText;
        GameObject effects;
        GameObject mapRandomizer;
        public EndGame(MonoBehaviour parent):base(parent)
        {
            gameManager = (GameManager)parent;
            startGame = gameManager.startGame;
            player = gameManager.player;
            music = gameManager.music;
            healthUI = gameManager.healthUI;
            healthText = gameManager.healthText;
            fps = gameManager.fps;
            fpsChecker = gameManager.fpsChecker;
            mapRandomizer = gameManager.MapRandomizer;
            effects = gameManager.audioManager;
        }

        // Update is called once per frame
        public override void Update()
        {
            if(!player.GetComponent<PlayerHealth>().isAlive)
            {
                music.GetComponent<MusicalAnimator>().source.Stop();
                effects.SetActive(false);
                //foreach (GameObject enemy in mapRandomizer.GetComponent<LevelGenerator>().enemies)
                //    enemy.GetComponent<Enemy>().enabled = false;
                //Stop Enemies when player die
                gameManager.Coroutine();

                gameManager.currentState = new GameStates.StartingGame(gameManager);
            }
        }
       
    }
}