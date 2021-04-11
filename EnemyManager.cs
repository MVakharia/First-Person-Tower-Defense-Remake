using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private float spawnDelay = 1;
    [SerializeField]
    private int enemiesRemainingThisRound;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private SpawnPoint[] spawnPoints;

    public int EnemiesRemainingThisRound => enemiesRemainingThisRound;
    public void SetEnemiesRemainingCounter() => enemiesRemainingThisRound = GameManager.Singleton.EnemiesThisRound;

    private void CountDownEnemiesRemaining() => enemiesRemainingThisRound--;


    private static EnemyManager singleton;

    public static EnemyManager Singleton
    {
        get
        {
            if (singleton == null)
            {
                singleton = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<EnemyManager>();
            }
            return singleton;
        }
    }

    public IEnumerator SpawnEnemies ()
    {
        while(enemiesRemainingThisRound > 0)
        {
            Instantiate(enemy, spawnPoints[0].transform.position, Quaternion.identity);

            CountDownEnemiesRemaining();

            yield return new WaitForSeconds(spawnDelay);
        }

        
    }

    private void Update()
    {
        
    }
}
