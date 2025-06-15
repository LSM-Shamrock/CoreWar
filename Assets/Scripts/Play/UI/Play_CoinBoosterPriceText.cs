using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Play_CoinBoosterPriceText : ObjectBase
{
    Text _text;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _text = GetComponentInChildren<Text>();
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            _text.text = $"{CoinBoosterPrice}";
            _text.color = CoinBoosterPrice > Coin ? Color.red : Color.yellow;
            yield return null;
        }
    }
}
