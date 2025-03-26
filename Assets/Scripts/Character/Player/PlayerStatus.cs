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
        //��� �� ������� CharacterDate������ �ް� �ִµ� ���� ���� Ŭ������ ����� ���� �� ���� ����
        characterDate = CharacterManager.Instance.Player.characterDate;
        if (characterDate != null)
        { UpdateCharacter(); }
    }
    public void UpdateCharacter()
    {
        characterDate = CharacterManager.Instance.Player.characterDate;

        //������ �÷��� �ɷ�ġ�� �ݿ��� �ȵȴ�... ���� ((characterDate.maxHp - characterDate.baseHp) * (characterDate.characterLevel / characterDate.characterMaxLevel))�� ���� �߸���...
        //
        characterMaxHP = characterDate.baseHp + ((characterDate.maxHp - characterDate.baseHp) * (characterDate.characterLevel / (float)characterDate.characterMaxLevel));
        characterAtk = characterDate.baseAtk + ((characterDate.maxAtk - characterDate.baseAtk) * (characterDate.characterLevel / (float)characterDate.characterMaxLevel));
        characterDef = characterDate.baseDef + ((characterDate.maxDef - characterDate.baseDef) * (characterDate.characterLevel / (float)characterDate.characterMaxLevel));

        if (characterHP <= 0)
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
