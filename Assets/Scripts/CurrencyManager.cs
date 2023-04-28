using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public int _egAmount;
    public int _goAmount;

    public void Init(string currencyCode, int balance)
    {
        switch (currencyCode)
        {
            case "GO":
                _goAmount = balance;
                break;
            case "EG":
                _egAmount = balance;
                break;
        }

    }
    private void Start()
    {
        // Get the current player's currency balances from PlayFab
        GetCurrencyBalances();
    }

    /*private void Update()
    {
        // Get the current player's currency balances from PlayFab
        GetCurrencyBalances();
    }*/

    public void GetCurrencyBalances()
    {
        // Call the PlayFab API to get the player's currency balances
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetCurrencyBalances, OnFailedModifyCurrency);
    }

    private void OnGetCurrencyBalances(GetUserInventoryResult result)
    {
        // Update the local currency balances
        _egAmount = result.VirtualCurrency["EG"];
        _goAmount = result.VirtualCurrency["GO"];
    }

    public void AddCurrency(VirtualCurrency virtualCurrency, int amountToAdd)
    {
        PlayFabClientAPI.AddUserVirtualCurrency(new PlayFab.ClientModels.AddUserVirtualCurrencyRequest()
        {
            Amount = amountToAdd,
            VirtualCurrency = virtualCurrency.ToString()
        }, OnSuccessfulModifyCurrency, OnFailedModifyCurrency);
    }

    public void SubtractCurrency(VirtualCurrency virtualCurrency, int amountToAdd)
    {
        PlayFabClientAPI.SubtractUserVirtualCurrency(new PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest()
        {
            Amount = amountToAdd,
            VirtualCurrency = virtualCurrency.ToString()
        }, OnSuccessfulModifyCurrency, OnFailedModifyCurrency);
    }

    private void OnSuccessfulModifyCurrency(ModifyUserVirtualCurrencyResult result)
    {
        switch (result.VirtualCurrency)
        {
            case "GO":

                _goAmount = result.Balance;
                Debug.Log($"GO:{_goAmount}");
                break;
            case "EG":
                _egAmount = result.Balance;
                Debug.Log($"EG:{_egAmount}");
                break;
        }


    }
    public bool HasEnoughEnergy(int amount)
    {
        // Check if the player has enough energy to play
        Debug.Log($"EG: {_egAmount}, Required: {amount} ");
        return _egAmount >= amount;
    }

    private void OnFailedModifyCurrency(PlayFabError error)
    {
        Debug.LogError(error.ToString());
    }

    public enum VirtualCurrency
    {
        EG,
        GO
    }

    [ContextMenu("Test Add and Subtract")]
    public void TestSubtract()
    {
        AddCurrency(VirtualCurrency.GO, 1000);
        SubtractCurrency(VirtualCurrency.EG, 1);
    }
}
