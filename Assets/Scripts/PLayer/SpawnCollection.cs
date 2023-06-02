using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollection : MonoBehaviour
{
    [SerializeField]private GameObject[] prefabs;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float min;
    [SerializeField] private float max;

    private void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while(true)
        {
            var wanted = Random.Range(min, max);
            var position = new Vector3(wanted, transform.position.y, 0);
            GameObject gameObject = Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(timeSpawn);
        }
    }
}
