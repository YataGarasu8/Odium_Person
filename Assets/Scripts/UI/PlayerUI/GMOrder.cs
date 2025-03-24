using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMOrder : MonoBehaviour
{
    public ItemDate BatItem;

    public void ClickGetBat()
    {
        CharacterManager.Instance.Player.inventory.AddItem(BatItem);
    }
}
