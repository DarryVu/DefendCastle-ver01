using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float mintras;
    [SerializeField] private float maxtras;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(true)
        {
            var wanted = Random.Range(mintras, maxtras);
            var position = new Vector3(transform.position.x, wanted);
            GameObject gameObject = Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(timeSpawn);       
        }
    }
}
