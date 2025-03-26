using System.Collections;
using System.Collections.Generic;
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

    public CharacterDescription description;
    public StatusUI status;

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
        characterMaxHP = (characterDate.baseHp + ((characterDate.maxHp - characterDate.baseHp) * (characterDate.characterLevel / characterDate.characterMaxLevel)));
        characterAtk = (characterDate.baseAtk + ((characterDate.maxAtk - characterDate.baseAtk) * (characterDate.characterLevel / characterDate.characterMaxLevel)));
        characterDef = (characterDate.baseDef + ((characterDate.maxDef - characterDate.baseDef) * (characterDate.characterLevel / characterDate.characterMaxLevel)));

        if (characterHP <= 0)
        {
            characterHP = characterMaxHP;
        }
        characterSprite.sprite = characterDate.characterSprite;

        description.UpdateDescription();
        status.UpdateStatus();
    }
}
