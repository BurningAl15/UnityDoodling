using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GameStates
{
    public class Playing : AbstractGameObjectStates
    {
        GameObject player;
        GameObject mapRandomizer;
        GameObject music;
        Image healthUI;
        Text healthText;
        float fps;
        Text fpsChecker;
        private GameManager gameManager;

        // Use this for initialization
        public Playing(MonoBehaviour parent):base(parent)
        {
            gameManager = (GameManager)parent;
            mapRandomizer = gameManager.MapRandomizer;
            music = gameManager.music;
            player = gameManager.player;
            healthUI = gameManager.healthUI;
            healthText = gameManager.healthText;
            fps = gameManager.fps;
            fpsChecker = gameManager.fpsChecker;
            music.GetComponent<MusicalAnimator>().source.Play();
        }

        // Update is called once per frame
        public override void Update()
        {
            if(player.GetComponent<PlayerHealth>().isAlive)
            { 
                //foreach (GameObject enemy in mapRandomizer.GetComponent<LevelGenerator>().enemies)
                //{
                //    if (enemy != null)
                //        enemy.GetComponent<Enemy>().WakeUp();
                //    else
                //        mapRandomizer.GetComponent<LevelGenerator>().enemies.Remove(enemy);
                //}

                //UI
                fps = 1 / Time.deltaTime;
                fpsChecker.text = "FPS: " + Mathf.Round(fps);

                healthUI.fillAmount = player.GetComponent<PlayerHealth>().health;

                if (healthUI.fillAmount < 1f)
                {
                    player.GetComponent<PlayerHealth>().health += 0.01f * Time.deltaTime;
                }

                healthText.text = "" + Mathf.Round(player.GetComponent<PlayerHealth>().health * 100) + "/ 100";

                if (healthUI.fillAmount >= 0.75f)
                    healthUI.color = Color.Lerp(Color.green, Color.yellow, 0.5f);
                else if (healthUI.fillAmount >= 0.5f && healthUI.fillAmount < 0.75f)
                    healthUI.color = Color.Lerp(Color.green, Color.red, 0.5f);
                else
                    healthUI.color = Color.red;

                if (player.GetComponent<PlayerHealth>().health <= 0)
                {
                    player.GetComponent<TopDownPlayer>().Animation();
                    gameManager.currentState = new GameStates.EndGame(gameManager);
                }
            }
        }
    }
}
