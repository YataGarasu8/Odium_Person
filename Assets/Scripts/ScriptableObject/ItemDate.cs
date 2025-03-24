using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipable,
    Expendable
}
[CreateAssetMenu(fileName = "ItemDate", menuName ="Scriptable Object/Itemdate")]
public class ItemDate : ScriptableObject
{
    [Header("Info")]
    public string itemName;
    public string itemDescription;
    public Sprite icon;
    public ItemType type;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("EquipStatus")]
    public float HP;
    public float Atk;
    public float Def;
}
