using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EddibleAliment : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    private AlimentDefinition alimentDefinition;

    public void Setup(AlimentDefinition alimentDefinition)
    {
        this.alimentDefinition = alimentDefinition;
        _sprite.sprite = alimentDefinition.alimentSprite;
    }

    public AlimentDefinition GetAlimentDefinition()
    {
        return alimentDefinition;
    }
}
