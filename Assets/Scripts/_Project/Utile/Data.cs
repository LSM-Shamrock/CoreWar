using System.Collections.Generic;

public class Data 
{
    public static readonly Dictionary<MonsterType, SummonInfo> MonsterSummonInfos = new()
    {
        [MonsterType.Slime] = new() { price = 496, cooltime = 4, },
        [MonsterType.Bat] = new() { price = 730, cooltime = 4, },
        [MonsterType.Goblin] = new() { price = 970, cooltime = 10, },
        [MonsterType.WaveSpirit] = new() { price = 1330, cooltime = 20, },
        [MonsterType.Skeleton] = new() { price = 1710, cooltime = 20, },
        [MonsterType.Dragon] = new() { price = 1840, cooltime = 20, },
        [MonsterType.Golem] = new() { price = 2840, cooltime = 15, },
        [MonsterType.ElecDragon] = new() { price = 4170, cooltime = 35, },
    };


}
