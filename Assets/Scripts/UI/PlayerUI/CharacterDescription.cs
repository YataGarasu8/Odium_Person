using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterDescription : MonoBehaviour
{
    CharacterDate date;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI descriptionText;

    public void UpdateDescription()
    {
        date = CharacterManager.Instance.Player.characterDate;
        nameText.text = date.characterName;
        levelText.text = $"LV.{date.characterLevel}/{date.characterMaxLevel}";
        descriptionText.text = date.characterDescription;
    }
}
