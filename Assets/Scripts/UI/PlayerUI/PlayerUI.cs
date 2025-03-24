using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject characterWindow;
    public GameObject inventoryWindow;
    public GameObject statusWindow;

    public void ClickCharacter()
    {
        characterWindow.SetActive(true);
        inventoryWindow.SetActive(false);
        statusWindow.SetActive(false);
    }
    public void ClickStatus()
    {
        inventoryWindow.SetActive(true);
        characterWindow.SetActive(false);
        statusWindow.SetActive(false);
    }
    public void ClickInventory()
    {
        statusWindow.SetActive(true);
        inventoryWindow.SetActive(false);
        characterWindow.SetActive(false);
    }
}
