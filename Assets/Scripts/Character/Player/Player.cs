using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDate characterDate;
    public ItemDate itemDate;
    
    public int gold;
    public TextMeshProUGUI goldText;

    public InventoryUI inventory;
    public PlayerStatus status;
   
    private void Awake()
    {
        CharacterManager.Instance.Player = this;
    }
    private void Update()
    {
        goldText.text = gold.ToString();
    }

}
