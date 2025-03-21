using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public ItemSlot[] slots;
    public ItemSlot itemSlots;

    public GameObject inventoryWindow;

    [Header("Select Item")]
    private ItemSlot selectItem;
    private int selectItemIndex;
    public int maxSlotcount;
    public TextMeshProUGUI slotCountText;
    public Transform Content;

    private void Start()
    {

    }
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
    public void AddItem()//������ �߰�
    {
        ItemDate date = CharacterManager.Instance.Player.itemDate;

        if(date.canStack)//�ߺ��� ������ �������� ���
        {
            ItemSlot slot = GetStackItemSlot(date);//���� ������ �������� �˻�

            if(slot != null)//���� ������ �������� ���� ���(null�� ��ȯ���� �ʾҴٸ�)
            {
                slot.quantity++;

                CharacterManager.Instance.Player.itemDate = null;
                return;
            }
        }
        if(slots.Length < maxSlotcount)
        {
            Instantiate(itemSlots,Content);
        }

    }
    public void SelectItem(int index)
    {
        
    }
    ItemSlot GetStackItemSlot(ItemDate date)//���� ������ �������� �˻�
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].itemDate == date && slots[i].quantity < date.maxStackAmount)
            {
                return slots[i];
            }
        }
        return null;
    }
}
