using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public List<EddibleAliment> _spawns = new List<EddibleAliment>();
    public float _spawnVariation = 2f;
    public float _spawnTime = 1.5f;
    private float _nextSpawnAllowed = 0;

    public void Start()
    {
        _nextSpawnAllowed = _spawnTime + Random.Range(0f, _spawnVariation);
    }

    public void Update()
    {
        if (_nextSpawnAllowed <= 0)
        {
            int indexChoosen = Random.Range(0, _spawns.Count);
            EddibleAliment spawned = Instantiate(_spawns[indexChoosen], this.transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
            _nextSpawnAllowed = _spawnTime + Random.Range(0f, _spawnVariation);
        }
        _nextSpawnAllowed -= Time.deltaTime;
    }
}
