using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour{

    public GameObject fruit;
    public Transform[] spawnPoints;

    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 1f;

    // Start is called before the first frame update
    void Start(){
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(!LifeControl.isOver){
            float timer = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(1f);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
            Destroy(spawnedFruit, 5f);
        }
    }

}
