using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    //[SerializeField] private float spawnRate = 1f;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private TimeManager timeManager;
    //private float nextSpawnTime = 0f;
    // Start is called before the first frame update
    void Start()
    {

        foreach (Transform position in spawnPositions)
        {
            SpawnObject(objects[RandomObjectNumber()], position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Time.timeSinceLevelLoad > nextSpawnTime && timeManager.gameOver == false && timeManager.gameFinished == false)
        //{
        //    // Sonraki çalýþma zamanýný güncelle
        //    nextSpawnTime += spawnRate;
        //    SpawnObject(objects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
            
        //}
    }
    private void SpawnObject(GameObject objectToSpawn,Transform newTransform)
    {
       Instantiate(objectToSpawn,newTransform.position, new Quaternion(0, 180, 0, 0));
    }
    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }

    private int RandomObjectNumber()
    {
        return Random.Range(0, objects.Length);
    }

}
