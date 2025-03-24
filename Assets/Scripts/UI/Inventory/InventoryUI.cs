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
        return inventoryWindow.activeInHierarchy;//â�� �����ִ��� ����
    }
    public void Toggle()//â �״� ����
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
    public void AddItem(ItemDate date)//������ �߰�
    {
        if (date.canStack)//�ߺ��� ������ �������� ���
        {
            ItemSlot slot = GetStackItemSlot(date);//���� ������ �������� �˻�

            if (slot != null)//���� ������ �������� ���� ���(null�� ��ȯ���� �ʾҴٸ�)
            {
                slot.quantity++;
                UpdateUI();
                return;
            }
        }
        if (slots.Count < maxSlotcount)//�κ��丮 ���� ������ ���� ���� ���
        {
            GameObject itemSlot = Instantiate(itemSlots, Content);
            itemSlot.GetComponent<ItemSlot>().itemDate = date;
            slots.Add(itemSlot.GetComponent<ItemSlot>()); // ����Ʈ�� �߰�
            UpdateUI();
            return;
        }

        return;
    }
    ItemSlot GetStackItemSlot(ItemDate date)//���� ������ �������� �˻�
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
