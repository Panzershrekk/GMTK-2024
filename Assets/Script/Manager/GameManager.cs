using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using DG.Tweening;
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
    [SerializeField] private float _slimeObjective = 10f;
    [SerializeField] private List<AlimentDefinition> _possibleAliments = new List<AlimentDefinition>();
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TreadmillHandler _treadmillHandler;
    [SerializeField] private SpawnHandler _spawnerHandler;
    [SerializeField] private List<Slime> _slimeList = new List<Slime>();
    [SerializeField] private EndPanel _endPanel;
    [SerializeField] private float _currentRoundTimeInSecond = 180f;
    [SerializeField] private TMP_Text _objectiveSlimeOneText;
    [SerializeField] private TMP_Text _objectiveSlimeTwoText;

    private bool _gameStarted = false;
    private UnityEvent _onGameStarted = new UnityEvent();
    private UnityEvent _onGameEnded = new UnityEvent();

    public float CurrentRoundTime
    {
        get
        {
            return _currentRoundTimeInSecond;
        }

        private set
        {
            _currentRoundTimeInSecond = value;
            UpdateTimerText(_currentRoundTimeInSecond);
        }
    }

    private void Start()
    {
        _onGameStarted.AddListener(_treadmillHandler.Setup);
        _onGameStarted.AddListener(_spawnerHandler.Setup);
        _onGameEnded.AddListener(_spawnerHandler.Stop);
        foreach (Slime slime in _slimeList)
        {
            slime.Setup();
        }
        _objectiveSlimeOneText.text = _slimeObjective.ToString() + " KG";
        _objectiveSlimeTwoText.text = _slimeObjective.ToString() + " KG";
        CurrentRoundTime = _currentRoundTimeInSecond;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(2f);
        sequence.Play();

        sequence.OnComplete(() =>
        {
            StartGame();
        });
    }

    public void StartGame()
    {
        _gameStarted = true;
        _onGameStarted?.Invoke();
    }

    private void Update()
    {
        if (_gameStarted == true)
        {
            CurrentRoundTime -= Time.deltaTime;
            if (CurrentRoundTime <= 0)
            {
                //FinsihGame
                _gameStarted = false;
                _onGameEnded?.Invoke();
                _endPanel.gameObject.SetActive(true);
                FreezeAllAliment();
                bool victory = true;
                foreach (Slime slime in _slimeList)
                {
                    if (slime.GetSize() < _slimeObjective)
                    {
                        victory = false;
                    }
                }
                _endPanel.Display(victory);
            }
        }
    }

    public AlimentDefinition GetRandomAlimentFromPossibility()
    {
        return _possibleAliments[UnityEngine.Random.Range(0, _possibleAliments.Count)];
    }

    public List<AlimentDefinition> GetNotValidatedAlimentInSlimeCombination()
    {
        List<AlimentDefinition> alimentDefinitions = new List<AlimentDefinition>();
        foreach (Slime slime in _slimeList)
        {
            List<CombinationPart> combinationParts = slime.GetCombination().GetCombinationPart();
            foreach (CombinationPart combinationPart in combinationParts)
            {
                if (combinationPart.isValidated == false)
                {
                    alimentDefinitions.Add(combinationPart.alimentDefinition);
                }
            }
        }
        return alimentDefinitions;
    }

    private void UpdateTimerText(float time)
    {
        TimeSpan t = TimeSpan.FromSeconds(time);
        string formatedTime = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        if (_timerText != null)
        {
            _timerText.text = formatedTime;
        }
    }

    private void FreezeAllAliment()
    {
        var aliments = FindObjectsByType<EddibleAliment>(FindObjectsSortMode.None);
        foreach (var aliment in aliments)
        {
            Rigidbody2D r = aliment.GetComponent<Rigidbody2D>();
            if (r != null)
            {
                r.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }

    }

    private void OnDestroy()
    {
        _onGameStarted.RemoveAllListeners();
        _onGameEnded?.RemoveAllListeners();
    }
}
