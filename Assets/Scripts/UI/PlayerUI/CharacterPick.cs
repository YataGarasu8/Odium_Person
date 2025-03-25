using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPick : MonoBehaviour
{
    public CharacterDate date;

    public void ClickCharacterPick()
    {
        CharacterManager.Instance.Player.characterDate = date;
        CharacterManager.Instance.Player.status.UpdateCharacter();
    }
}
