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

    }
    public void SelectItem(ItemDate date)
    {
        if (date != null)
        {
            ItemNameText.text = date.itemName;
            ItemExplainText.text = date.itemDescription;
        }
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
}
