using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDate characterDate;
    public ItemDate itemDate;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
}
