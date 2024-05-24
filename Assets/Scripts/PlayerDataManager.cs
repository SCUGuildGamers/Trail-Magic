using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public void ResetPlayerData()
    {
        // set coordinates to starting position
        
    }

    public void SetToTitle()
    {
        // set coordinates to starting position
        
        
        playerData.checkpoint = 0;
    }
}
