using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public PlayerStatus status;

    public TextMeshProUGUI HPText;
    public TextMeshProUGUI AtkText;
    public TextMeshProUGUI DefText;

    public void UpdateStatus()
    {
        HPText.text = $"{status.characterHP.ToString("N0")}/{status.characterMaxHP.ToString("N0")}";
        AtkText.text = status.characterAtk.ToString("N0");
        DefText.text= status.characterDef.ToString("N0");
    }
}
