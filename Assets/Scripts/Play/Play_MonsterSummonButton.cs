using JetBrains.Annotations;
using System.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

public class Play_MonsterSummonButton : ObjectBase
{
    Image _image;

    int _deckIndex;

    public void Init(int deckIndex)
    {
        _deckIndex = deckIndex;
        _image = GetComponent<Image>();
        _image.sprite = GetMonsterButtonSprite(Deck[deckIndex]);

        StartCoroutine(Loop_Summon());
        StartCoroutine(Loop_Brightness());
    }

    IEnumerator Loop_Summon()
    {
        while (true)
        {
            MonsterType monsterType = Deck[_deckIndex];

            bool isCooltime = (MonsterOnCooltime.ContainsKey(monsterType) && MonsterOnCooltime[monsterType] > 0f);

            int price = MonsterSummonInfo[monsterType].price;
            int cooltime = MonsterSummonInfo[monsterType].cooltime;

            if (!isCooltime && IsContactMousePointer && IsClickedMouse)
            {
                transform.localScale = Vector3.one * 25f;
                yield return WaitUntil(() => !IsClickedMouse);
                transform.localScale = Vector3.one * 30f;

                if (IsContactMousePointer && Coin >= price)
                {
                    MonsterOnCooltime[monsterType] = cooltime;
                    Coin -= price;
                    AllyToSummon = monsterType;
                    
                    while (MonsterOnCooltime[monsterType] > 0f)
                    {
                        yield return null;
                        MonsterOnCooltime[monsterType] -= Time.deltaTime;
                    }
                }
            }
            yield return WaitForFixedUpdate;
        }
    }

    IEnumerator Loop_Brightness()
    {
        while (true)
        {
            MonsterType monsterType = Deck[_deckIndex];

            bool isCooltime = (MonsterOnCooltime.ContainsKey(monsterType) && MonsterOnCooltime[monsterType] > 0f);

            int price = MonsterSummonInfo[monsterType].price;
            int cooltime = MonsterSummonInfo[monsterType].cooltime;

            if (isCooltime)
            {
                float f = MonsterOnCooltime[monsterType] / cooltime; 
                float brightness = Mathf.Lerp(-0.1f, -0.9f, f);
                Utile.SetBrightness(_image, brightness);
            }
            else
            { 
                Utile.SetBrightness(_image, 0f);
            }

            yield return WaitForFixedUpdate;
        }
    }
}
