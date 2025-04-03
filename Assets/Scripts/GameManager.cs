using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public FirstPersonController playerController;
    public float spawnTime;
    public float lastSpawnTime;
    public GameObject Enemy;
    public TextMeshProUGUI health;
    public TextMeshProUGUI timerText;
    public float timer;
    public bool upgradeTime;
    public int kills = 2;
    public int neededKills;
    public TextMeshProUGUI killCounter;

    void Start()
    {
        playerController = player.GetComponent<FirstPersonController>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        lastSpawnTime -= Time.deltaTime;
            if(lastSpawnTime <= 0){
            Vector3 spawnVector;
            float spawnPoint = Random.Range(-65,65);
            bool flip = Random.Range(0,1.0f) > 0.5f; 
            bool flip2 = Random.Range(0,1.0f) > 0.5f;
            float flip3 = 1;

            if(flip2) flip3 = -1;
            if(flip) {
            spawnVector = new Vector3(spawnPoint , 3 , 65 * flip3);
            }
            else spawnVector = new Vector3(65*flip3 , 3 , spawnPoint);
           
            NPCController enemyScript = Instantiate(Enemy, spawnVector, Quaternion.identity).GetComponent<NPCController>();
            enemyScript.Target = player;
            enemyScript.gameManager = this;
            lastSpawnTime = spawnTime - timer/120.0f;

            if(kills >= neededKills)
            {
                kills = 0;
                neededKills += 2;
                upgradeTime = true;
            }

            
            }

        health.text = "Health: " + playerController.health + " / " + playerController.maximumHealth;
        timerText.text = (int)(timer / 60) + " : " + (int) timer % 60;
        killCounter.text = "Kills: " + (int) kills + " / " + (int) neededKills;
    }
}
