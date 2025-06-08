using System.Collections;
using UnityEngine;

public class Play_MonsterPrice : ObjectBase
{
    Textbox _textbox;

    int _deckIndex;

    //public void Init(int deckIndex)
    //{
    //    _deckIndex = deckIndex;
    //    _textbox = GetComponent<Textbox>();

    //    StartCoroutine(Loop());
    //}

    //IEnumerator Loop()
    //{
    //    MonsterType monsterType = Deck[_deckIndex];
    //    int price = MonsterSummonInfo[monsterType].price;
    //    _textbox.Text = $"{price}";
    //    if (price > Coin)
    //        _textbox.TextColor = Color.red;
    //    else
    //        _textbox.TextColor = Color.yellow;
    //}
}
