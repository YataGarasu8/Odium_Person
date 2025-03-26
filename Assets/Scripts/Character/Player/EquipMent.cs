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
        //status.characterDef += date.Def;//아이템 사용도 고려하면 따로 빼는 게 맞지만... 아닌가?
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
