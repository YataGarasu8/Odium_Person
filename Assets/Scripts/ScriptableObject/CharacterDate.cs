using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDate", menuName = "Scriptable Object/Characterdate")]
public class CharacterDate : ScriptableObject
{
    public Sprite characterSprite;
    public string characterName;
    public int characterLevel;
    public int characterMaxLevel;
    public float maxHp;
    public float maxAtk;
    public float maxDef;
    public float baseHp;
    public float baseAtk;
    public float baseDef;

    public string characterDescription;
}
