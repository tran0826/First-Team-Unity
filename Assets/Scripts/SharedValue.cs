﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedValue : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public double Time { get; set; } = 0f;
    public float Hp { get; set; }
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
    Thunder
}

public enum LevelType
{
    Interval,
    Total,
    Power
}