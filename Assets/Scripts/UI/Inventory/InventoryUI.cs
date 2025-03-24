using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<ItemSlot> slots;

    public GameObject itemSlots;
    public GameObject inventoryWindow;

    [Header("Select Item")]
    private ItemSlot selectItem;
    private int selectItemIndex;
    public int maxSlotcount;
    public TextMeshProUGUI slotCountText;
    public TextMeshProUGUI ItemNameText;
    public TextMeshProUGUI ItemStatusText;
    public TextMeshProUGUI ItemExplainText;
    public GameObject equipButton;
    public GameObject useButton;
    public GameObject trashButton;

    public Transform Content;

    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;//창이 켜져있는지 여부
    }
    public void Toggle()//창 켰다 끄기
    {
        if (IsOpen())
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemDate != null)
            {
                slots[i].Set();
                slots[i].index = i;
            }
            else
            {
                slots[i].Clear();
            }
        }
        slotCountText.text = $"{slots.Count}/{maxSlotcount}";
    }
    public void AddItem(ItemDate date)//아이템 추가
    {
        if (date.canStack)//중복이 가능한 아이템일 경우
        {
            ItemSlot slot = GetStackItemSlot(date);//같은 종류의 아이템을 검색

            if (slot != null)//같은 종류의 아이템이 있을 경우(null로 반환되지 않았다면)
            {
                slot.quantity++;
                UpdateUI();
                return;
            }
        }
        if (slots.Count < maxSlotcount)//인벤토리 보유 상한을 넘지 않을 경우
        {
            GameObject itemSlot = Instantiate(itemSlots, Content);
            itemSlot.GetComponent<ItemSlot>().itemDate = date;
            slots.Add(itemSlot.GetComponent<ItemSlot>()); // 리스트에 추가
            UpdateUI();
            return;
        }

        return;
    }
    ItemSlot GetStackItemSlot(ItemDate date)//같은 종류의 아이템을 검색
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].itemDate == date && slots[i].quantity < date.maxStackAmount)
            {
                return slots[i];
            }
        }
        return null;
    }
    public void SelectItem(int index)
    {
        if (slots[index].itemDate == null)
        { return; }

        selectItem = slots[index];
        selectItemIndex = index;

        ItemNameText.text = selectItem.itemDate.itemName;
        ItemExplainText.text = selectItem.itemDate.itemDescription;

        if(selectItem.itemDate.type == ItemType.Equipable)
        {
            ItemStatusText.text = $"HP {selectItem.itemDate.HP} Atk {selectItem.itemDate.Atk} Def {selectItem.itemDate.Def}";
            equipButton.SetActive(true);
            useButton.SetActive(false);
        }
        else
        {
            useButton.SetActive(true);
            equipButton.SetActive(false);
        }
        trashButton.SetActive(true);
    }
    public void ClickEquip()
    {
        if(selectItem.equipped)
        {
            selectItem.equipped = false;
            UpdateUI();
        }
        else
        {
            for(int i = 0; i < slots.Count; i++)
            {
                if (slots[i].equipped)
                {
                    slots[i].equipped = false;
                }
            }
            selectItem.equipped = true;
            UpdateUI();
        }
    }
    public void ClickTrash()
    {

    }
}
