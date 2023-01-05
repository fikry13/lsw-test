using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wallet
{
    [SerializeField]
    private int _gold;

    public Action<int> onWalletValueChange;

    public int Gold 
    {
        get { return _gold; }
    }

    public bool HasEnoughGold(int amount)
    {
        return _gold >= amount;
    }

    public void Add(int amount)
    {
        _gold += amount;
        onWalletValueChange?.Invoke(_gold);
    }

    public bool Subtract(int amount)
    {
        if(HasEnoughGold(amount))
        {
            _gold -= amount;
            onWalletValueChange?.Invoke(_gold);
            return true;
        }

        Debug.Log("Not Enough Gold");
        return false;
    }
}
