using System.Collections;
using UnityEngine;

public class Play_Coin : ObjectBase
{
    private void Start()
    {
        Init();
    }

    void Init()
    {
        Coin = 750;
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return WaitForSeconds(1f / CoinBooster);
            Coin += 125;
        }
    }
}
