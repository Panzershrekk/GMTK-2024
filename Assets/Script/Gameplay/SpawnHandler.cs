using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] List<AlimentSpawner> _spawns = new List<AlimentSpawner>();
    [SerializeField] EddibleAliment _alimentToSpawn;
    [SerializeField] float _spawnTime = 2f;
    private float _nextSpawnAllowed = 0;

    // Update is called once per frame
    void Update()
    {
        _nextSpawnAllowed -= Time.deltaTime; 

        if (_nextSpawnAllowed <= 0)
        {
            int indexChoosen = Random.Range(0, _spawns.Count);
            _spawns[indexChoosen].Spawn(_alimentToSpawn, GameManager.Instance.GetRandomAlimentFromPossibility());
            _nextSpawnAllowed = _spawnTime;
        }
    }
}
