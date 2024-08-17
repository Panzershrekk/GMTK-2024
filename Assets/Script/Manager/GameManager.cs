using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
// THIS CLASS US SINGLETON PATTERN
//

public class GameManager : MonoBehaviour
{
    #region Singleton pattern

    /*
    ** Singleton pattern
    */

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [SerializeField] private List<AlimentDefinition> _possibleAliments = new List<AlimentDefinition>(); 

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public bool IsGameStarted = false;
    public bool IsGameOver = false;
   
    public void StartGame()
    {
        IsGameStarted = true;
    }

    public void FinishGame()
    {
        IsGameOver = true;
    }

    public AlimentDefinition GetRandomAlimentFromPossibility()
    {
        return _possibleAliments[Random.Range(0, _possibleAliments.Count)];
    }
}
