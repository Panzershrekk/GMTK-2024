using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Slime : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _slimeBouncer;

    [SerializeField] private TMP_Text _sizeText;

    [SerializeField] private int _combinationSize;
    [SerializeField] private Combination _combination;
    [SerializeField] private float _sizeGainPerSuccess = 1f;

    [Header("Slime")]
    [SerializeField] private Transform slimeParent;
    [SerializeField] private SpriteRenderer mouthCloseSprite;
    [SerializeField] private SpriteRenderer slimeTopSprite;
    [SerializeField] private SpriteRenderer slimeDownSprite;
    [SerializeField] private SpriteRenderer mouthSprite;
    [SerializeField] private SpriteRenderer tongueSprite;

    [SerializeField] float largeSizeThreshold = 8f;
    [SerializeField] private float bigSizeThreshold = 5f;
    [SerializeField] private float mediumSizeThresold = 3f;

    [Header("SlimeConfig")]
    [SerializeField] private SlimeConfig smallConfig;
    [SerializeField] private SlimeConfig mediumConfig;
    [SerializeField] private SlimeConfig bigConfig;
    [SerializeField] private SlimeConfig largeConfig;

    private float _currentSize = 1;

    public void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(_slimeBouncer.DOScale(1.05f, 1f).SetEase(Ease.Linear))
                .Append(_slimeBouncer.DOScale(1f, 1f).SetEase(Ease.Linear));
        sequence.SetLoops(-1);
        sequence.Play();
    }

    public void Setup()
    {
        _combination.GenerateNewCombination(_combinationSize);
        _sizeText.text = _currentSize.ToString();
    }

    public void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.I))
        {
            LoadSlimeConfig(mediumConfig);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadSlimeConfig(bigConfig);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadSlimeConfig(largeConfig);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            LoadSlimeConfig(smallConfig);
        }
#endif
    }

    public void LoadSlimeConfig(SlimeConfig config)
    {

        Sequence sequence = DOTween.Sequence();
        sequence.Append(slimeParent.DOScaleX(1.2f, 0.2f).SetEase(Ease.Linear))
                .Join(slimeParent.DOScaleY(1.2f, 0.2f).SetEase(Ease.Linear))
                .Append(slimeParent.DOScaleX(0.6f, 0.2f).SetEase(Ease.Linear))
                .Join(slimeParent.DOScaleY(0.3f, 0.2f).SetEase(Ease.Linear));
        sequence.Play();

        sequence.OnComplete(() =>
        {
            mouthCloseSprite.sprite = config.spriteMouthClosed;
            slimeTopSprite.sprite = config.spriteTop;
            slimeDownSprite.sprite = config.spriteDown;
            mouthSprite.sprite = config.spriteMouth;
            tongueSprite.sprite = config.spriteTongue;

            slimeParent.localPosition = new Vector3(0, config.yOffset, 0);
            sequence = DOTween.Sequence();
            sequence.Append(slimeParent.DOScaleX(1f, 0.2f).SetEase(Ease.Linear))
                    .Join(slimeParent.DOScaleY(1f, 0.2f).SetEase(Ease.Linear));
            sequence.Play();
        });

    }

    public void GainSize()
    {
        _currentSize += _sizeGainPerSuccess;
        if (_currentSize >= largeSizeThreshold)
        {
            LoadSlimeConfig(largeConfig);
        }
        else if (_currentSize >= bigSizeThreshold)
        {
            LoadSlimeConfig(bigConfig);
        }
        else if (_currentSize >= mediumSizeThresold)
        {
            LoadSlimeConfig(mediumConfig);
        }
        _sizeText.text = _currentSize.ToString();
    }

    public Combination GetCombination()
    {
        return _combination;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != null)
        {
            EddibleAliment eddibleAliment = col.gameObject.GetComponent<EddibleAliment>();
            if (eddibleAliment != null)
            {
                _animator.Play("Eat");
                //_combination.CheckForCombination(eddibleAliment.GetAlimentDefinition());
                if (_combination.CheckForCombination(eddibleAliment.GetAlimentDefinition()) == true)
                {
                    _combination.GenerateNewCombination(_combinationSize);
                    GainSize();
                }
            }
            Destroy(col.gameObject);
        }
    }

    public float GetSize()
    {
        return _currentSize;
    }
}
