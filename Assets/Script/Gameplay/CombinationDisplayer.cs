using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinationDisplayer : MonoBehaviour
{
    [SerializeField] private UICombinationPart _UICombinationPart;
    [SerializeField] private Transform _combinationPartParent;
    private List<UICombinationPart> _createdCombiParts = new List<UICombinationPart>();

    public void RefreshUI(List<CombinationPart> _combinationPart)
    {
        int i = 0;
        GameObject[] allChildren = new GameObject[_combinationPartParent.childCount];
        foreach (Transform child in _combinationPartParent.transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        foreach (GameObject child in allChildren)
        {
            Destroy(child);
        }
        _createdCombiParts.Clear();
        foreach (CombinationPart part in _combinationPart)
        {
            UICombinationPart UICombinationPart = Instantiate(_UICombinationPart, _combinationPartParent);
            UICombinationPart.Setup(part);
        }
    }


}
