using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float timeSpawn;
    private float checkSpawnEnemy = -2.2f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(true)
        {
            var position = new Vector3(transform.position.x, checkSpawnEnemy);
            GameObject gameObject = Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(timeSpawn);       
        }
    }
}
