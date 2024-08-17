using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [SerializeField] List<AlimentSpawner> _spawns = new List<AlimentSpawner>();
    [SerializeField] EddibleAliment _alimentToSpawn;
    [SerializeField] float _spawnTime = 2f;
    [SerializeField] float _spawnVariation = 1.5f;
    [SerializeField] float _probabilityOfUnvalidatedAlimentToSpawn = 0.70f;
    private float _nextSpawnAllowed = 0;
    private bool _canSpawn = false;

    public void Setup()
    {
        _canSpawn = true;
    }

    public void Stop()
    {
        _canSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canSpawn == true)
        {
            _nextSpawnAllowed -= Time.deltaTime;

            if (_nextSpawnAllowed <= 0)
            {
                int indexChoosen = Random.Range(0, _spawns.Count);
                AlimentDefinition alimentDefinition = null;

                float unvalidatedProb = Random.Range(0f, 1f);
                if (unvalidatedProb < _probabilityOfUnvalidatedAlimentToSpawn)
                {
                    alimentDefinition = ChooseFromUnvalidatedCombination();
                }
                if (alimentDefinition == null)
                {
                    alimentDefinition = GameManager.Instance.GetRandomAlimentFromPossibility();
                }
                _spawns[indexChoosen].Spawn(_alimentToSpawn, alimentDefinition);
                _nextSpawnAllowed = _spawnTime + Random.Range(0f, _spawnVariation);
            }
        }
    }

    AlimentDefinition ChooseFromUnvalidatedCombination()
    {
        List<AlimentDefinition> possibilities = GameManager.Instance.GetNotValidatedAlimentInSlimeCombination();
        if (possibilities.Count > 0)
            return possibilities[Random.Range(0, possibilities.Count)];
        return null;
    }
}
