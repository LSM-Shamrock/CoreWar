using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lobby_MonsterCardButton : ObjectBase, IPointerClickHandler
{
    private enum PositionType 
    { 
        List, 
        Deck, 
    }

    private PositionType _positionType; 

    public void OnPointerClick(PointerEventData eventData)
    {


    }

    public void Init()
    {
        switch (Enum.Parse<Lobby_SceneGameObjects>(transform.parent.name))
        {
            case Lobby_SceneGameObjects.MonsterCardButtonGroup_CardList:
                _positionType = PositionType.List; 
                break;

            case Lobby_SceneGameObjects.MonsterCardButtonGroup_CardDeck:
                _positionType = PositionType.Deck;
                break;
        }

        StartCoroutine(Loop_SpeechMonsterInfo());
        StartCoroutine(Loop_UpdateList());

    }

    private IEnumerator Loop_SpeechMonsterInfo()
    {
        while (true)
        {
            if (IsContactMousePointer)
            {
                // TODO
                int price = 0;
                int cooltime = 0;
                Speech($"가격:{price}코인, 쿨타임:{cooltime}초");
            }
            else
            {
                RemoveSpeachbubble();
            }

            yield return null;
        }
    }

    private IEnumerator Loop_UpdateList()
    {
        if (_positionType != PositionType.List)
            yield break;

        while (true)
        {


            yield return null;
        }
    }
}
