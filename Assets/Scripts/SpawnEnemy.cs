using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform[] _spawnPoint;

    private void Start()
    {
        EventManager.LeftTheCastle += StartSpawnEnemy;
    }

    private void OnEnable()
    {
        EventManager.LeftTheCastle -= StartSpawnEnemy;
    }

    private void StartSpawnEnemy()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            var point = Random.Range(0, _spawnPoint.Length);
            var enemy = Instantiate(_enemy, _spawnPoint[point].position, Quaternion.identity);
            enemy.SetActive(true);
            yield return new WaitForSeconds(6f);
        }
    }
}
