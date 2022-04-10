using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject sheepPreFAB;
    public List<Transform> sheepSpawnPosition = new List<Transform>();
    public float spawnCooldown;
    private List<GameObject> sheepList = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private void SpawnSheep()
    {
        Vector3 randomPosition = sheepSpawnPosition[Random.Range(0, sheepSpawnPosition.Count)].position;
        GameObject sheep = Instantiate(sheepPreFAB, randomPosition, sheepPreFAB.transform.rotation);
        sheepList.Add(sheep);
        sheep.GetComponent<Sheep>().SetSpawner(this);
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }
    public void DestroyAllSheep()
    {
        foreach (GameObject sheep in sheepList) { Destroy(sheep);}
        sheepList.Clear();
    }
}
