using System.Collections;
using UnityEngine;

public class Play_MonsterGenerator : Play_ObjectBase
{
    Transform _monsterRoot;
    Transform _monsterHpBarRoot;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _monsterRoot = GameObject.Find(Play_FindGameObject.MonsterRoot.ToString()).transform;
        _monsterHpBarRoot = GameObject.Find(Play_FindGameObject.MonsterHpBarRoot.ToString()).transform;

        SummonedMonsterCount = 0;
    }

    void CreateMonster(Vector3 position)
    {
        var prefab = Utile.LoadResource<GameObject>(Utile.Enum2Path(Prefabs.Play.Monster));
        var go = Utile.CreateClone(prefab);
        var monster = go.GetComponent<Play_Monster>();
        go.transform.SetParent(_monsterRoot);
        go.transform.position = position;
        monster.Init();
    }

    // 몬 소환
    IEnumerator Loop_SummonMonster()
    {
        Vector3 position = new();
        while (true)
        {
            if (SummonAlly != MonsterType.None || SummonEnemy != MonsterType.None)
            {
                SummonedMonsterCount++;
                if (SummonAlly != MonsterType.None)
                {
                    position = BlueCore.position;
                    AllyOrEnemys[SummonedMonsterCount] = AllyOrEnemy.Ally;
                    MonsterTypes[SummonedMonsterCount] = SummonAlly;
                    SummonAlly = MonsterType.None;
                }
                else if (SummonEnemy != MonsterType.None)
                {
                    position = RedCore.position;
                    AllyOrEnemys[SummonedMonsterCount] = AllyOrEnemy.Enemy;
                    MonsterTypes[SummonedMonsterCount] = SummonEnemy;
                    SummonEnemy = MonsterType.None;
                }
                position.y += Utile.RandomNumber(0, 20);
                position.x += Utile.RandomNumber(-10, 10);
                CreateMonster(position);

                yield return WaitForSeconds(0.01f);
            }
            yield return null;
        }
    }
}
