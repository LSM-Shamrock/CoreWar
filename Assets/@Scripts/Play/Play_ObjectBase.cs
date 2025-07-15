using System.Collections.Generic;
using UnityEngine;

public enum Play_FindGameObject
{
    MonsterRoot,
    MonsterHpBarRoot,
}

public class Play_ObjectBase : ObjectBase
{

    public static Transform BlueCore;
    public static Transform RedCore;

    public static int Coin;
    public static float CoinBooster;
    public static int CoinBoosterPrice => (int)(CoinBooster * 350);
    public static Dictionary<MonsterType, float> MonsterOnCooltime = new();
    public static MonsterType SummonAlly;
    public static MonsterType SummonEnemy;
    public static int SummonedMonsterCount;

    public static MonsterType[] MonsterTypes = new MonsterType[5000];
    public static int[] MonsterRemainingHPs = new int[5000];
    public static int[] MonsterMaximumHPs = new int[5000];
    public static float[] MonsterXs = new float[5000];
    public static float[] MonsterYs = new float[5000];
    public static GroundOrFlying[] GroundOrFlyings = new GroundOrFlying[5000];
    public static AllyOrEnemy[] AllyOrEnemys = new AllyOrEnemy[5000];
    public static int[] MonsterKnockbacks = new int[5000];
    public static bool[] IsMonsterProjectileCall = new bool[5000];

    public static int? FrontAlly;
    public static int? FrontEnemy;
    public static int? FrontGroundAlly;
    public static int? FrontGroundEnemy;
}
