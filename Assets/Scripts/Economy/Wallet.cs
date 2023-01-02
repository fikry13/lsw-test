using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Gold { get; private set; }

    public bool HasEnoughGold(int amount)
    {
        return Gold >= amount;
    }

    public void Add(int amount)
    {
        Gold += amount;
    }

    public bool Subtract(int amount)
    {
        if(HasEnoughGold(amount))
        {
            Gold -= amount;
            return true;
        }

        Debug.Log("Not Enough Gold");
        return false;
    }
}
