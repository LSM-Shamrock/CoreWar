using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ObjectBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 변수
    protected static float Difficulty;
    protected static List<Sprites.Monsters> Deck;


    // 흐름
    protected WaitUntil WaitUntil(Func<bool> predicate)
    {
        return new WaitUntil(predicate);
    }
    protected WaitWhile WaitWhile(Func<bool> predicate)
    {
        return new WaitWhile(predicate);
    }
    protected IEnumerable Count(int n)
    {
        for (int i = 0; i < n; i++)
        {
            yield return i;
        }
    }


    // 입력
    protected bool IsContactMousePointer { get; private set; }
    protected bool IsMouseClicked { get; private set; }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        IsContactMousePointer = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        IsContactMousePointer = false;
    }
    protected virtual void Update()
    {
        IsMouseClicked = Input.GetMouseButton(0);
    }


    // 말하기
    static Transform SpeechbubbleRoot
    {
        get
        {
            if (s_speechbubbleRoot == null)
            {
                s_speechbubbleRoot = Utile.FindGameObject(CoreObjects.SpeechbubbleCanvas).transform;
            }
            return s_speechbubbleRoot;
        }
    }
    static Transform s_speechbubbleRoot;
    static Dictionary<Transform, Speechbubble> s_speechbubbles = new();
    protected void Speech(string text)
    {
        Speechbubble speechbubble;
        if (s_speechbubbles.TryGetValue(transform, out var saved) && saved != null)
        {
            speechbubble = saved;
        }
        else
        {
            var prefab = Utile.LoadResource<GameObject>(Prefabs.Core.Speechbubble);
            var go = Instantiate(prefab, SpeechbubbleRoot);
            speechbubble = go.GetComponent<Speechbubble>();
            speechbubble.Init(transform);
            s_speechbubbles[transform] = speechbubble;
        }
        speechbubble.Show(text);
    }
    protected void RemoveSpeachbubble()
    {
        if (s_speechbubbles.TryGetValue(transform, out var speechbubble))
        {
            speechbubble = s_speechbubbles[transform];
            speechbubble.Hide();
        }
    }
    protected IEnumerator SpeechForSeconds(string text, float seconds)
    {
        Speech(text);
        yield return new WaitForSeconds(seconds);
        RemoveSpeachbubble();
    }
}
