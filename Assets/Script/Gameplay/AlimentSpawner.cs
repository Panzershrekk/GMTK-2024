using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlimentSpawner : MonoBehaviour
{
    public void Spawn(EddibleAliment toSpawn, AlimentDefinition alimentDefinition)
    {
        EddibleAliment spawned = Instantiate(toSpawn, this.transform.position, Quaternion.identity);
        spawned.Setup(alimentDefinition);
    }
}
