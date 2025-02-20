using System;
using UnityEngine;

[RequireComponent(typeof(ChildrenCollector))]
public abstract class UIBase : MonoBehaviour 
{
    private ChildrenCollector _childrenCollector;

    protected void Awake()
    {
        _childrenCollector = GetComponent<ChildrenCollector>();
        _childrenCollector.CollectChildren();
    }

    protected Transform GetChildByName(string name)
    {
        var result = _childrenCollector.GetChild((transform) => transform.name == name);
        if (result == null)
        {
            Debug.LogError( $"\"{gameObject.name}\"오브젝트에 \"{name}\"이름을 가진 하위 오브젝트가 없습니다.");
        }
        return result;
    }
}
