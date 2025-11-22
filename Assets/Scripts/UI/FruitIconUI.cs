using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays fruit icon in the top right corner when player has fruits in backpack
/// Shows different fruit sprite based on the fruit type in backpack
/// </summary>
public class FruitIconUI : MonoBehaviour
{
    [SerializeField] PlayerBackpack backpack;
    [SerializeField] Image fruitImage;
    
    // Array of fruit sprites matching BushVariant order: Green, Cyan, Yellow
    [SerializeField] Sprite[] fruitSprites = new Sprite[3];
    
    void Start()
    {
        // Start with fruit icon hidden (disable the Image component, not the GameObject)
        if (fruitImage != null)
        {
            fruitImage.enabled = false;
        }
    }
    
    void Update()
    {
        // Show fruit icon if backpack has fruits, hide if empty
        if (backpack != null && fruitImage != null)
        {
            if (backpack.current > 0 && backpack.currentFruitType.HasValue)
            {
                // Get the fruit type and corresponding sprite
                BushVariant fruitType = backpack.currentFruitType.Value;
                int fruitTypeIndex = (int)fruitType;
                
                // Show fruit icon (enable the Image component)
                if (!fruitImage.enabled)
                {
                    fruitImage.enabled = true;
                }
                
                // Update sprite based on fruit type
                if (fruitTypeIndex >= 0 && fruitTypeIndex < fruitSprites.Length && fruitSprites[fruitTypeIndex] != null)
                {
                    fruitImage.sprite = fruitSprites[fruitTypeIndex];
                }
            }
            else
            {
                // Hide fruit icon when backpack is empty (disable the Image component)
                if (fruitImage.enabled)
                {
                    fruitImage.enabled = false;
                }
            }
        }
    }
}
