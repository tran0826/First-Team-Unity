using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SharedValue : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public double Time { get; set; } = 0f;
    public float Hp { get; set; }
    public int FireLevel { get; set; } = 0;
    public int WaterLevel { get; set; } = 0;
    public int ThunderLevel { get; set; } = 0;
    public int NormalLevel { get; set; } = 0;
}


namespace Common
{
    public static class Define
    {
        public const int MAX_LEVEL = 2;
    }
}

public enum BulletType
{
    Fire,
    Water,
    Thunder
}

public enum TileType
{
    Road,
    Grass
}

public enum TowerType
{
    None,
    Fire,
    Water,
    Thunder,
    Normal
}

public enum LevelType
{
    Interval,
    Total,
    Power
}