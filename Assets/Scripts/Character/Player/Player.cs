using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDate characterDate;
    public ItemDate itemDate;
    public int Gold;

    public InventoryUI inventory;
    public CharacterStatus status;
   
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
}
