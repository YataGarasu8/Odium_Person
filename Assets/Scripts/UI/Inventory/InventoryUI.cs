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
    public void AddItem()//아이템 추가
    {
        ItemDate date = CharacterManager.Instance.Player.itemDate;

        if(date.canStack)//중복이 가능한 아이템일 경우
        {
            ItemSlot slot = GetStackItemSlot(date);//같은 종류의 아이템을 검색

            if(slot != null)//같은 종류의 아이템이 있을 경우(null로 반환되지 않았다면)
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
    ItemSlot GetStackItemSlot(ItemDate date)//같은 종류의 아이템을 검색
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
