using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemDate itemDate;

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;

    public int index;
    public bool equipped;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    private void OnEnable()
    {
        outline.enabled = equipped;
    }
    public void Set()
    {
        icon.sprite = itemDate.icon;
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;
        
        if(outline != null)
        {
            outline.enabled = equipped;
        }
    }
    public void Clear()
    {
        Destroy(this.gameObject);
    }
    public void OnClickButton()
    {
        CharacterManager.Instance.Player.inventory.SelectItem(index);
    }    
}
