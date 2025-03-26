using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMOrder : MonoBehaviour
{
    public ItemDate batItem;
    public ItemDate portionItem;

    public void ClickGetBat()
    {
        CharacterManager.Instance.Player.inventory.AddItem(batItem);
    }
    public void ClickGetportion()
    {
        CharacterManager.Instance.Player.inventory.AddItem(portionItem);
    }
    public void ClickAddGold()
    {
        CharacterManager.Instance.Player.AddGold(5);
    }
}
