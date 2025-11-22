using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to store the fruits harvested with <see cref="PlayerHarvest"/> from <see cref="BushFruits"/>
/// </summary>
public class PlayerBackpack : MonoBehaviour
{
    public int max;
    public int current;
    public BushVariant? currentFruitType; // Current fruit type in backpack, null if empty

    public void AddFruits(int amount, BushVariant fruitType)
    {
        current += amount;
        currentFruitType = fruitType; // Store the fruit type
        if (current > max)
        {
            current = max;
        }
    }
    public int TakeFruits()
    {
        int ret = current;
        current = 0;
        currentFruitType = null; // Clear fruit type when taking all fruits
        return ret;
    }
}
