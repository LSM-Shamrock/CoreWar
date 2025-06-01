using UnityEngine;
using UnityEngine.UIElements;

public class Lobby_MonsterCardButtonGenerator : ObjectBase
{
    private void Start()
    {
        Init();
    }

    private void Init()
    {
        Vector3 position = new();

        position.x = -40f * 3;
        position.y = -110f;
        foreach (int i in Count(7))
        {
            CreateCardButton(position);
            position.x += 40f;
        }

        position.y = 120f;
        foreach (int i in Count(9))
        {
            position.x = 180f;

            CreateCardButton(position);
            
            position.x += 40f;

            CreateCardButton(position);
            
            position.y -= 30f;
        }
    }

    private void CreateCardButton(Vector3 position)
    {
        var prefab = Utile.LoadPrefab(Prefabs.MonsterCardButton);
        var go = Utile.CreateClone(prefab);
        go.transform.SetParent(transform);
        go.transform.position = position;
    }
}
