using System;
using System.Linq;
using UnityEngine;

public class Lobby_MonsterButtonSetup : ObjectBase
{
    private GameObject _buttonPrefab;
    private Transform _deckRoot;
    private Transform _listRoot;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _buttonPrefab = Utile.LoadResource<GameObject>(Utile.Enum2Path(Prefabs.Lobby.MonsterButton));

        _deckRoot = transform.GetChild(0);
        _listRoot = transform.GetChild(1);

        MonsterType[] monsterTypes = Enum.GetValues(typeof(MonsterType))
            .Cast<MonsterType>().Where(a => MonsterSummonInfo.ContainsKey(a)).ToArray();

        for (int i = 0; i < 7; i++)
        {
            CreateButton(MonsterButtonType.Deck, i, monsterTypes[i % monsterTypes.Length]);
        }

        for (int i = 0; i < 18; i++)
        {
            CreateButton(MonsterButtonType.List, i, monsterTypes[i % monsterTypes.Length]);
        }
    }

    private void CreateButton(MonsterButtonType buttonType, int num, MonsterType monsterType)
    {
        GameObject go = Utile.CreateClone(_buttonPrefab);
        if (buttonType == MonsterButtonType.List) go.transform.SetParent(_listRoot);
        if (buttonType == MonsterButtonType.Deck) go.transform.SetParent(_deckRoot);

        Lobby_MonsterButton button = go.GetComponent<Lobby_MonsterButton>();
        button.Init(buttonType, num, monsterType);
    }
}
