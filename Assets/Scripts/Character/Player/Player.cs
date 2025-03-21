using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ItemDate itemDate;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
}
