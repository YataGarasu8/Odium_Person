using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMent : MonoBehaviour
{
    public PlayerStatus status;

    public void Equip(ItemDate date)
    {
        CharacterManager.Instance.Player.itemDate = date;
        //status.characterMaxHP += date.HP;
        //status.characterHP += date.HP;
        //status.characterAtk += date.Atk;
        //status.characterDef += date.Def;//������ ��뵵 ����ϸ� ���� ���� �� ������... �ƴѰ�?
    }
    public void UnEquip()
    {
        ItemDate date = CharacterManager.Instance.Player.itemDate;

        if (date != null)
        {
            //status.characterMaxHP -= date.HP;
            //status.characterHP -= date.HP;
            //status.characterAtk -= date.Atk;
            //status.characterDef -= date.Def;
            CharacterManager.Instance.Player.itemDate = null;
        }
    }
}
