using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum MonsterButtonType
{
    List,
    Deck,
}

public class Lobby_MonsterButton : ObjectBase
{
    Image _image;

    MonsterButtonType _buttonType;
    int _number;

    MonsterType _monsterType;
    MonsterType MonsterType
    {
        get { return _monsterType; }
        set
        {
            _monsterType = value;
            _image.sprite = Utile.LoadResource<Sprite>($"Sprites/MonsterButtons/{_monsterType.ToString()}");
        }
    }


    public void Init(MonsterButtonType buttonType, int number, MonsterType monsterType)
    {
        _image = GetComponent<Image>();

        _buttonType = buttonType;
        _number = number;
        MonsterType = monsterType;
        
        OnClickAction = OnClick;
        StartCoroutine(Loop_ShowInfo());
        StartCoroutine(Loop_List());
        StartCoroutine(Loop_Deck());
    }

    private void OnClick()
    {
        if (_buttonType == MonsterButtonType.List)
        {
            if (Var.SelectedCard == MonsterType) 
                Var.SelectedCard = MonsterType.None;
            else
                Var.SelectedCard = MonsterType;
        }
        else
        {
            if (Var.SelectedCard != MonsterType.None)
            {
                MonsterType = Var.SelectedCard;
                Var.SelectedCard = MonsterType.None;
            }
        }
    }

    IEnumerator Loop_ShowInfo()
    {
        while (true)
        {
            SummonInfo summonInfo = Data.MonsterSummonInfos[MonsterType];

            if (IsContactMousePointer)
                ShowSpeechbubble($"가격:{summonInfo.price}코인, 쿨타임:{summonInfo.cooltime}초");
            else
                HideSpeachbubble();

            yield return WaitForFixedUpdate();
        }
    }

    IEnumerator Loop_List()
    {
        if (_buttonType != MonsterButtonType.List)
            yield break;

        while (true)
        {
            if (Var.SelectedCard == MonsterType)
                transform.localScale = Vector3.one * 20f;
            else
                transform.localScale = Vector3.one * 30f;

            if (Var.Deck.Any(t => t == MonsterType))
                Utile.SetBrightness(_image, -0.5f);
            else
                Utile.SetBrightness(_image, 0f);

            yield return WaitForFixedUpdate();
        }
    }

    IEnumerator Loop_Deck()
    {
        if (_buttonType != MonsterButtonType.Deck)
            yield break;

        while (true)
        {
            Var.Deck[_number] = MonsterType;
            yield return WaitForFixedUpdate();
        }
    }
}
