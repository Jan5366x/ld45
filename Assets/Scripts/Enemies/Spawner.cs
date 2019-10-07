using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnerWave[] waves;
    public bool playerInRange;

    IEnumerator SpawnPickups(SpawnerWave item)
    {
        yield return new WaitForSeconds(Random.Range(item.delayMin, item.delayMax));
        if (playerInRange)
        {
            SpawnAround(item);
        }
    }

    void SpawnAround(SpawnerWave wave)
    {
        int count = Random.Range(wave.countMin, wave.countMax);
        for (int i = 0; i < count; i++)
        {
            var position = transform.position;
            var range = wave.spawnerRange;
            float spawnX = Random.Range(position.x - range.x, position.x + range.x);
            float spawnY = Random.Range(position.y - range.y, position.y + range.y);

            Instantiate(wave.prefab, new Vector3(spawnX, spawnY), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            playerInRange = true;
            foreach (var wave in waves)
            {
                StartCoroutine("SpawnPickups", wave);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            playerInRange = false;
            StopAllCoroutines();
        }
    }
}