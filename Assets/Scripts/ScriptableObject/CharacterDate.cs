using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDate", menuName = "Scriptable Object/Characterdate")]
public class CharacterDate : ScriptableObject
{
    public Sprite characterSprite;
    public string characterName;
    public int characterLevel;
    public float maxHp;
    public float maxAtk;
    public float maxDef;
}
