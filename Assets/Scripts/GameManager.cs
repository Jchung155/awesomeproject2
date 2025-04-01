using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public float spawnTime;
    public float lastSpawnTime;
    public GameObject Enemy;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lastSpawnTime -= Time.deltaTime;
            if(lastSpawnTime <= 0){
            Vector3 spawnVector;
            float spawnPoint = Random.Range(-65,65);
            bool flip = (int) Random.Range(0,1) == 1; 
            bool flip2 = (int) Random.Range(0,1) == 1;
            float flip3 = 1;
            if(flip2) flip3 = -1;
            if(flip) {
            spawnVector = new Vector3(spawnPoint , 3 , 65 * flip3);
            }
            else spawnVector = new Vector3(65*flip3 , 3 , spawnPoint);
            Instantiate(Enemy, spawnVector, Quaternion.identity);
            lastSpawnTime = spawnTime;
            }
    }
}
