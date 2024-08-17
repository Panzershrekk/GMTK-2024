using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AlimentDefinition", order = 1)]
public class AlimentDefinition : ScriptableObject
{
    public AlimentType alimentType;
    public Sprite alimentSprite;
}
