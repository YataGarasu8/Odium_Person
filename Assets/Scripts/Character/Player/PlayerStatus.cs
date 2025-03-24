using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    CharacterDate characterDate;
    private void Start()
    {
        characterDate = CharacterManager.Instance.Player.characterDate;
    }
}
