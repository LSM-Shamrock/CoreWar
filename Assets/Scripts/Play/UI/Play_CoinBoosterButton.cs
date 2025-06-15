using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Play_CoinBoosterButton : ObjectBase
{
    Image _image;
    
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _image = GetComponent<Image>();

        CoinBooster = 1f;
        StartCoroutine(Loop());
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            transform.localScale = Vector3.one * 30f;
            if (CoinBoosterPrice > Coin)
            {
                Utile.SetBrightness(_image, -0.75f);
            }
            else
            {
                Utile.SetBrightness(_image, 0f);

                if (IsContactMousePointer && IsClickedMouse)
                {
                    transform.localScale = Vector3.one * 25f;
                    yield return WaitWhile(() => IsClickedMouse);
                    if (IsContactMousePointer && CoinBoosterPrice <= Coin)
                    {
                        Coin -= CoinBoosterPrice;
                        CoinBooster += 0.1f;
                    }
                }
            }
            yield return WaitForFixedUpdate;
        }
    }
}
