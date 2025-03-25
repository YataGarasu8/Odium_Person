using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    CharacterDate characterDate;

    [Header("CharaterStatus")]
    public float characterMaxHP;
    public float characterHP;
    public float characterAtk;
    public float characterDef;
    public Image characterSprite;

    public CharacterDescription description;
    public StatusUI status;

    private void Start()
    {
        characterDate = CharacterManager.Instance.Player.characterDate;
        if (characterDate != null)
        { UpdateCharacter(); }
    }
    public void UpdateCharacter()
    {
        characterDate = CharacterManager.Instance.Player.characterDate;
        characterMaxHP = 250 + ((characterDate.maxHp - 250) * (characterDate.characterLevel / characterDate.characterMaxLevel));
        characterAtk = 150 + ((characterDate.maxAtk - 150) * (characterDate.characterLevel / characterDate.characterMaxLevel));
        characterDef = 80 + ((characterDate.maxDef - 80) * (characterDate.characterLevel / characterDate.characterMaxLevel));
        if (characterHP <= 0)
        {
            characterHP = characterMaxHP;
        }
        characterSprite.sprite = characterDate.characterSprite;

        description.UpdateDescription();
    }
}
