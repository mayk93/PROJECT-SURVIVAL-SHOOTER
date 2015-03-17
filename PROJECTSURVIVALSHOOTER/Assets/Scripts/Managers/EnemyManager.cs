using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    /* To Refactor: */
    /* 
     * Instead of 3 instances of this script,
     * change enemy to be an array:
     * 
     * public GameObject[] enemy;
     * Instantiate (enemy[ Random.Range(0,enemy.range) ], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
     * */
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
