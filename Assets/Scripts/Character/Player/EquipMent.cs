using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMent : MonoBehaviour
{
    public void Equip(ItemDate date)
    {
        CharacterManager.Instance.Player.itemDate = date;
    }
    public void UnEquip()
    {
        CharacterManager.Instance.Player.itemDate = null;
    }
}
