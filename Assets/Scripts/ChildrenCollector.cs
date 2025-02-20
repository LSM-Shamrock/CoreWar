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
                $"{nameof(_collectedChildren)}�� �Ҵ���� �ʾҽ��ϴ�.\n" + 
                $"{nameof(CollectChildren)}�� �̸� ȣ���� �ּ���");
        }
        return _collectedChildren;
    }

    public Transform GetChild(Func<Transform, bool> predicate)
    {
        if (_collectedChildren == null)
        {
            Debug.LogError(
                $"{nameof(_collectedChildren)}�� �Ҵ���� �ʾҽ��ϴ�.\n" +
                $"{nameof(CollectChildren)}�� �̸� ȣ���� �ּ���");
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