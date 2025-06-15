using System.Collections;
using UnityEngine;

public class Play_CoinText : ObjectBase
{
    Textbox _textbox;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _textbox = GetComponent<Textbox>();
        StartCoroutine(Loop());
    }
    
    IEnumerator Loop()
    {
        while (true)
        {
            _textbox.Text = $"   ";
            _textbox.Text += Coin.ToString();
            _textbox.Text += " ";
            yield return WaitForFixedUpdate;
        }
    }
}
