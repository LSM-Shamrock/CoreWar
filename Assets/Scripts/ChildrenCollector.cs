using System;
using UnityEngine;

public class ChildrenCollector : MonoBehaviour
{
    private Transform[] _collectedChildren;

    public void CollectChildren()
    {
        _collectedChildren = GetComponentsInChildren<Transform>();
    }

    public Transform[] GetCollectedChildren()
    {
        if (_collectedChildren == null)
        {
            Debug.LogError(
                $"{nameof(_collectedChildren)}이 할당되지 않았습니다.\n" + 
                $"{nameof(CollectChildren)}을 미리 호출해 주세요");
        }
        return _collectedChildren;
    }

    public Transform GetChild(Func<Transform, bool> predicate)
    {
        if (_collectedChildren == null)
        {
            Debug.LogError(
                $"{nameof(_collectedChildren)}이 할당되지 않았습니다.\n" +
                $"{nameof(CollectChildren)}을 미리 호출해 주세요");
            return null;
        }
        foreach (var child in _collectedChildren)
        {
            if (predicate(child))
            {
                return child;
            }
        }
        return null;
    }
}