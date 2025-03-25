using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject characterWindow;
    public GameObject inventoryWindow;
    public GameObject statusWindow;
    public GameObject playerText;

    private void Start()
    {
        characterWindow.SetActive(true);
        playerText.SetActive(true);
        inventoryWindow.SetActive(false);
        statusWindow.SetActive(false);
    }

    public void ClickCharacter()
    {
        characterWindow.SetActive(true);
        playerText.SetActive(true);
        inventoryWindow.SetActive(false);
        statusWindow.SetActive(false);
    }
    public void ClickStatus()
    {
        statusWindow.SetActive(true);
        playerText.SetActive(true);
        characterWindow.SetActive(false);
        inventoryWindow.SetActive(false);
    }
    public void ClickInventory()
    {
        inventoryWindow.SetActive(true);
        playerText.SetActive(false);
        statusWindow.SetActive(false);
        characterWindow.SetActive(false);
    }
}
