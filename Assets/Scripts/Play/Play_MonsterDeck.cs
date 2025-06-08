using UnityEngine;

public class Play_MonsterDeck : ObjectBase
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        GameObject prefab = Utile.LoadResource<GameObject>(Utile.Enum2Path(Prefabs.Play.MonsterSummonButton));
        
        for (int i = 0; i < 7; i++)
        {
            var go = Utile.CreateClone(prefab);
            var button = go.GetComponent<Play_MonsterSummonButton>();
            button.transform.SetParent(transform);
            button.Init(i);
        }
    }
}
