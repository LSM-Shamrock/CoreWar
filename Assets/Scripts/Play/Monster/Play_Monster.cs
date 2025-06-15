using System.Collections;
using UnityEngine;

public class Play_Monster : Play_ObjectBase
{
    int _number;

    public void Init()
    {
        _number = SummonedMonsterCount;

        Init_Monster();
        StartCoroutine(Routine_CheckingDeath());

        StartCoroutine(Loop_UpdateMonsterInfo());

    }

    void Init_Monster()
    {
        MonsterType monsterType = MonsterTypes[_number];

        Sprite sprite = GetMonsterSprite(monsterType);
        Utile.SetSpriteAndAsyncPolygon(gameObject, sprite);

        float size = default;
        int monsterMaximumHp = default;
        GroundOrFlying groundOrFlying = default;
        switch (monsterType)
        {
            case MonsterType.Slime:
            case MonsterType.EnemySlime:
                size = 30f;
                monsterMaximumHp = 30;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.Bat:
                size = 35f;
                monsterMaximumHp = 23;
                groundOrFlying = GroundOrFlying.Flying;
                break;
            case MonsterType.DevilCloud:
                size = 35f;
                monsterMaximumHp = 40;
                groundOrFlying = GroundOrFlying.Flying;
                break;
            case MonsterType.Dragon:
            case MonsterType.ElecDragon:
                size = 40f;
                monsterMaximumHp = 40;
                groundOrFlying = GroundOrFlying.Flying;
                break;
            case MonsterType.Skeleton:
            case MonsterType.DarkSkeleton:
                size = 35;
                monsterMaximumHp = 39;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.Golem:
                size = 50f;
                monsterMaximumHp = 180;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.EnemySpider:
                size = 30f;
                monsterMaximumHp = 30;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.BomBot:
                size = 40f;
                monsterMaximumHp = 35;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.Goblin:
                size = 35f;
                monsterMaximumHp = 30;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.WaveSpirit:
                size = 50f;
                monsterMaximumHp = 40;
                groundOrFlying = GroundOrFlying.Ground;
                break;
            case MonsterType.Cyclops:
                size = 100f;
                monsterMaximumHp = 640;
                groundOrFlying = GroundOrFlying.Ground;
                break;
        }

        transform.localScale = Vector3.one * size;
        GroundOrFlyings[_number] = groundOrFlying;
        MonsterMaximumHPs[_number] = monsterMaximumHp;
        MonsterRemainingHPs[_number] = monsterMaximumHp;
    }

    void DeleteThisObject()
    {
        Destroy(gameObject);
    }

    IEnumerator Routine_CheckingDeath()
    {
        yield return WaitUntil(() => MonsterRemainingHPs[_number] <= 0);
        
        if (MonsterTypes[_number] == MonsterType.BomBot)
            IsMonsterProjectileCall[_number] = true;

        DeleteThisObject();
    }

    IEnumerator Loop_UpdateMonsterInfo()
    {
        while (true)
        {
            MonsterXs[_number] = transform.position.x;
            MonsterYs[_number] = transform.rotation.y;

            if (AllyOrEnemys[_number] == AllyOrEnemy.Ally)
            {
                bool isChangeToFrontAlly = 
                    FrontAlly == null 
                    || MonsterRemainingHPs[FrontAlly.Value] <= 0
                    || transform.position.x > MonsterXs[FrontAlly.Value];
                if (isChangeToFrontAlly) 
                    FrontAlly = _number;
                
                if (GroundOrFlyings[_number] == GroundOrFlying.Ground)
                {
                    bool isChangeToFrontGroundAlly =
                        FrontGroundAlly == null
                        || MonsterRemainingHPs[FrontGroundAlly.Value] <= 0
                        || transform.position.x > MonsterXs[FrontGroundAlly.Value];
                    if (isChangeToFrontGroundAlly)
                        FrontGroundAlly = _number;
                }
            }
            if (AllyOrEnemys[_number] == AllyOrEnemy.Enemy)
            {
                bool isChangeToFrontEnemy =
                    FrontEnemy == null
                    || MonsterRemainingHPs[FrontEnemy.Value] <= 0
                    || transform.position.x > MonsterXs[FrontEnemy.Value];
                if (isChangeToFrontEnemy)
                    FrontEnemy = _number;

                if (GroundOrFlyings[_number] == GroundOrFlying.Ground)
                {
                    bool isChangeToFrontGroundEnemy =
                        FrontGroundEnemy == null
                        || MonsterRemainingHPs[FrontGroundEnemy.Value] <= 0
                        || transform.position.x > MonsterXs[FrontGroundEnemy.Value];
                    if (isChangeToFrontGroundEnemy)
                        FrontGroundEnemy = _number;
                }
            }
            yield return null;
        }
    }
}
