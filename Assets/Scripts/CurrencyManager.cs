using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyManager : MonoBehaviour
{
    public int energy;
    public int goldGears;

    public TextMeshProUGUI energyValueText;
    public TextMeshProUGUI goldGearsValueText;

    public void Init(string currencyCode, int balance)
    {
        switch (currencyCode)
        {
            case "GG":
                goldGears = balance;
                break;
            case "EN":
                energy = balance;
                break;
        }

    }
    private void Start()
    {
        // Get the current player's currency balances from PlayFab
        GetCurrencyBalances();
    }

    private void Update()
    {
    }

    public void GetCurrencyBalances()
    {
        // Call the PlayFab API to get the player's currency balances
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetCurrencyBalances, OnFailedModifyCurrency);
    }

    private void OnGetCurrencyBalances(GetUserInventoryResult result)
    {
        // Update the local currency balances
        energy = result.VirtualCurrency["EN"];
        energyValueText.text = energy.ToString();

        goldGears = result.VirtualCurrency["GG"];
        goldGearsValueText.text = energy.ToString();
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
            case "GG":

                goldGears = result.Balance;
                Debug.Log($"GG:{goldGears}");
                break;
            case "EN":
                energy = result.Balance;
                Debug.Log($"EN:{energy}");
                break;
        }


    }
    public bool HasEnoughEnergy(int amount)
    {
        // Check if the player has enough energy to play
        Debug.Log($"EN: {energy}, Required: {amount} ");
        return energy >= amount;
    }

    private void OnFailedModifyCurrency(PlayFabError error)
    {
        Debug.LogError(error.ToString());
    }

    public enum VirtualCurrency
    {
        EN,
        GG
    }

    [ContextMenu("Test Add and Subtract")]
    public void TestSubtract()
    {
        AddCurrency(VirtualCurrency.GG, 1000);
        SubtractCurrency(VirtualCurrency.EN, 1);
    }
}
