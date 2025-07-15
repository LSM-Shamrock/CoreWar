using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Play_CoinBoosterLevelText : Play_ObjectBase
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
            _text.text = $"÷{CoinBooster:F1}";
            yield return null;
        }
    }
}
