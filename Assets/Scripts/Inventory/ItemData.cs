using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Only gameplay")]
    public string itemName;
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);
    
    [Header("Only UI")]
    public bool stackable = true;

    [Header("Gameplay and UI")]
    public Sprite image;
}

public enum ItemType {
    BuildingBlock,
    Tool,
    Potion,
    Weapon,
    Ingredient
}

public enum ActionType {
    Dig,
    Mine,
    Drink,
    Hit,
    Mix_Potion
}