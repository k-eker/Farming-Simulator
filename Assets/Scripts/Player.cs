using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int m_Coins;
    public int Coins 
    {
        get
        {
            return m_Coins;
        }
        set
        {
            m_Coins = value;

            GameManager.Instance.uiController.SetCoinsText(m_Coins);
        }
    
    }

    public bool CompareValues(int cost)
    {
        return Coins >= cost;
    }
}
