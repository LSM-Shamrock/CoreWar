using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    protected static float Difficulty;
    protected static List<Sprites.Monsters> Deck;




    #region 유틸
    protected bool IsMouseClicked;
    protected bool IsContactMousePointer;
    protected virtual void Update()
    {
        IsMouseClicked = Input.GetMouseButton(0);
    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        IsContactMousePointer = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        IsContactMousePointer = false;
    }

    protected WaitUntil WaitUntil(Func<bool> predicate)
    {
        return new WaitUntil(predicate);
    }
    
    protected IEnumerable Count(int n)
    {
        for (int i = 0; i < n; i++)
        {
            yield return i;
        }
    }
    #endregion
}
