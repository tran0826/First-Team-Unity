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

    public int IntervalLevel { get; set; } = 0;
    public int PowerLevel { get; set; } = 0;
    public int TotalLevel { get; set; } = 0;

    public bool TransFlag { get; set; } = false;
    public Scene NextScene { get; set; } = Scene.Title;
}


namespace Common
{
    public static class Define
    {
        public const int MAX_LEVEL = 2;
        public const int MAX_PLAYER_LEVEL = 29;

        public static readonly int[] LEVEL_UP_TABLE = new int[2] { 50, 50 };
        public static readonly int[] PLAYER_LEVEL_UP_TABLE = new int[29]
            {10,12,14,16,18,
             20,22,24,26,28,
             30,33,36,39,42,
             45,48,51,54,57,
             60,65,70,75,80,
             85,90,95,100
            };

        public const float MAX_INTERVAL = 1.0f;
        public const float MIN_INTERVAL = 0.3f;

        public const int MAX_POWER = 100;
        public const int MIN_POWER = 5;

    }
}

public enum BulletType
{
    Fire,
    Water,
    Thunder,
    Normal
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

public enum Scene
{
    Title,
    Game,
    Manual,
    GameOver,
    GameClear
}