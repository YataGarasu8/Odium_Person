using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    CharacterDate characterDate;

    [Header("CharaterStatus")]
    public float characterMaxHP;
    public float characterHP;
    public float characterAtk;
    public float characterDef;
    public Image characterSprite;

    [Header("StatusUI")]
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;

    public CharacterDescription description;

    private void Start()
    {
        //계속 이 방법으로 CharacterDate정보를 받고 있는데 차라리 따로 클래스를 만들어 빼는 게 좋을 지도
        characterDate = CharacterManager.Instance.Player.characterDate;
        if (characterDate != null)
        { UpdateCharacter(); }
    }
    public void UpdateCharacter()
    {
        characterDate = CharacterManager.Instance.Player.characterDate;

        characterMaxHP = characterDate.baseHp + ((characterDate.maxHp - characterDate.baseHp) * (characterDate.characterLevel / (float)characterDate.characterMaxLevel));
        characterAtk = characterDate.baseAtk + ((characterDate.maxAtk - characterDate.baseAtk) * (characterDate.characterLevel / (float)characterDate.characterMaxLevel));
        characterDef = characterDate.baseDef + ((characterDate.maxDef - characterDate.baseDef) * (characterDate.characterLevel / (float)characterDate.characterMaxLevel));
        
        if(CharacterManager.Instance.Player.itemDate != null)
        {
            characterMaxHP += CharacterManager.Instance.Player.itemDate.HP;
            characterHP += CharacterManager.Instance.Player.itemDate.HP;
            characterAtk += CharacterManager.Instance.Player.itemDate.Atk;
            characterDef += CharacterManager.Instance.Player.itemDate.Def;//아이템 사용도 고려하면 따로 빼는 게 맞지만... 아닌가?
        }
        if (characterHP <= 0)
        {
            characterHP = characterMaxHP;
        }
        if (characterHP >= characterMaxHP)
        {
            characterHP = characterMaxHP;
        }
        characterSprite.sprite = characterDate.characterSprite;

        HPText.text = $"{characterHP.ToString("N0")}/{characterMaxHP.ToString("N0")}";
        AtkText.text = characterAtk.ToString("N0");
        DefText.text = characterDef.ToString("N0");

        description.UpdateDescription();
    }
}
