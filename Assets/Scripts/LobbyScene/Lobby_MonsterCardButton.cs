using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lobby_MonsterCardButton : ObjectBase, IPointerClickHandler
{
    private enum PositionType { Collection, Deck, }

    private SpriteRenderer _sr;

    private PositionType _positionType;

    private Sprites.MonsterButtons _monster;

    private static Sprites.MonsterButtons? s_selected;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (_positionType)
        {
            case PositionType.Deck: Click_DeckCard(); break;
            case PositionType.Collection: Click_CollectionCard(); break;
        }
    }

    public void Init()
    {
        _sr = GetComponent<SpriteRenderer>();
        switch (Enum.Parse<Lobby_SceneGameObjects>(transform.parent.name))
        {
            case Lobby_SceneGameObjects.MonsterCardButtonGroup_CardDeck:
                _positionType = PositionType.Deck;
                break;
            case Lobby_SceneGameObjects.MonsterCardButtonGroup_CardCollection:
                _positionType = PositionType.Collection; 
                break;
        }
        StartCoroutine(Loop_ShowMonsterInfo());
        StartCoroutine(Loop_UpdateCollection());

    }

    private void Click_DeckCard()
    {
        if (s_selected != null)
            _monster = s_selected!.Value;
    }
    private void Click_CollectionCard()
    {
        if (s_selected == _monster)
            s_selected = null;
        else
            s_selected = _monster;
    }
    private IEnumerator Loop_UpdateCollection()
    {
        if (_positionType != PositionType.Collection)
            yield break;

        while (true)
        {

            yield return null;
        }
    }
    private IEnumerator Loop_ShowMonsterInfo()
    {
        while (true)
        {
            if (IsContactMousePointer)
            {
                int price = GetMonsterSummonPrice(_monster);
                int cooltime = GetMonsterSummonCooltime(_monster);
                Speech($"가격:{price}코인, 쿨타임:{cooltime}초");
            }
            else
                RemoveSpeachbubble();
            yield return null;
        }
    }

}
