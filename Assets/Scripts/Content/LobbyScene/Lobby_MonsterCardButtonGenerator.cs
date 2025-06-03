using UnityEngine;
using UnityEngine.UIElements;

public class Lobby_MonsterCardButtonGenerator : ObjectBase
{
    void Start()
    {
        Init();
    }

    void Init()
    {
        Init_CardDeck();
        Init_CardCollection();
    }

    void Init_CardDeck()
    {
        GameObject root = Utile.FindGameObject(Lobby_SceneGameObjects.MonsterCardButtonGroup_CardDeck);
        GameObject prefab = Utile.LoadPrefab(Prefabs.LobbyScene.MonsterCardButton);
        for (int i = 0; i < 7; i++)
        {
            var go = Utile.CreateClone(prefab);
            go.transform.SetParent(root.transform);
            var card = go.GetComponent<Lobby_MonsterCardButton>();
            card.Init();
        }
    }

    void Init_CardCollection()
    {
        GameObject root = Utile.FindGameObject(Lobby_SceneGameObjects.MonsterCardButtonGroup_CardCollection);
        GameObject prefab = Utile.LoadPrefab(Prefabs.LobbyScene.MonsterCardButton);
        for (int i = 0; i < 18; i++)
        {
            var go = Utile.CreateClone(prefab);
            go.transform.SetParent(root.transform);
            var card = go.GetComponent<Lobby_MonsterCardButton>();
            card.Init();
        }
    }
}
