using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Play_MonsterPriceText : Play_ObjectBase
{
    Text _textbox;
    int _deckIndex;

    public void Init(int deckIndex)
    {
        _deckIndex = deckIndex;
        _textbox = GetComponentInChildren<Text>();
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            MonsterType monsterType = Deck[_deckIndex];
            int price = MonsterSummonInfo[monsterType].price;

            _textbox.text = $"{price}";
            if (price > Coin)
                _textbox.color = Color.red;
            else
                _textbox.color = Color.yellow;

            yield return WaitForFixedUpdate; 
        }
    }
}
