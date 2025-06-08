using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ObjectBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    #region 유틸
    
    // 흐름
    protected IEnumerable Count(int n)
    {
        for (int i = 0; i < n; i++)
        {
            yield return i;
        }
    }
    protected WaitForFixedUpdate WaitForFixedUpdate()
    {
        return new WaitForFixedUpdate();
    }
    protected WaitForSeconds WaitForSeconds(float seconds)
    {
        return new WaitForSeconds(seconds);
    }
    protected WaitUntil WaitUntil(Func<bool> predicate)
    {
        return new WaitUntil(predicate);
    }
    protected WaitWhile WaitWhile(Func<bool> predicate)
    {
        return new WaitWhile(predicate);
    }


    // 입력
    protected Action OnClickAction;
    protected bool IsContactMousePointer { get; private set; }
    protected bool IsMouseClicked { get; private set; }
    protected virtual void Update()
    {
        IsMouseClicked = Input.GetMouseButton(0);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickAction?.Invoke();
    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        IsContactMousePointer = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        IsContactMousePointer = false;
    }


    // 말하기
    static Transform SpeechbubbleRoot
    {
        get
        {
            if (s_speechbubbleRoot == null)
            {
                s_speechbubbleRoot = Utile.FindGameObject("SpeechbubbleCanvas").transform;
            }
            return s_speechbubbleRoot;
        }
    }
    static Transform s_speechbubbleRoot;
    static Dictionary<Transform, Speechbubble> s_speechbubbles = new();
    protected void ShowSpeechbubble(string text)
    {
        Speechbubble speechbubble;
        if (s_speechbubbles.TryGetValue(transform, out var saved) && saved != null)
        {
            speechbubble = saved;
        }
        else
        {
            var prefab = Utile.LoadResource<GameObject>(Utile.Enum2Path(Prefabs._Project.Speechbubble));
            var go = Instantiate(prefab, SpeechbubbleRoot);
            speechbubble = go.GetComponent<Speechbubble>();
            speechbubble.Init(transform);
            s_speechbubbles[transform] = speechbubble;
        }
        speechbubble.Show(text);
    }
    protected void HideSpeachbubble()
    {
        if (s_speechbubbles.TryGetValue(transform, out var speechbubble))
        {
            speechbubble = s_speechbubbles[transform];
            speechbubble.Hide();
        }
    }
    protected IEnumerator ShowSpeechbubbleForSeconds(string text, float seconds)
    {
        ShowSpeechbubble(text);
        yield return new WaitForSeconds(seconds);
        HideSpeachbubble();
    }
    
    #endregion
}
