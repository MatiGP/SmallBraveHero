﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Player UI")]
    [SerializeField] private Image playerHealthBar = null;
    [SerializeField] private TextMeshProUGUI playerHealthText = null;
    [Header("PopUp Pooler")]
    [SerializeField] private PopUpPooler popUpPooler = null;

    private const string PLAYER_HEALTH_FORMAT = "{0}/{1}";


    private void Awake()
    {
        PlayerHealth.OnPlayerDamageTaken += HandlePlayerDamageTaken;
        Health.OnDamageTaken += Health_OnDamageTaken;
        Health.OnHealUp += Health_OnHealUp;
        
    }

    private void Health_OnHealUp(int val, Vector3 position)
    {
        Debug.Log("Healing damage! FROM POP");
        popUpPooler.SpawnPopUpFromQueue($"+{val}", position);
    }

    private void Health_OnDamageTaken(int val, Vector3 position)
    {
        Debug.Log("Taking damage! FROM POP");
        popUpPooler.SpawnPopUpFromQueue($"-{val}", position);
    }

    private void HandlePlayerDamageTaken(PlayerHealth playerHealth)
    {
        string healthAmountText = string.Format(PLAYER_HEALTH_FORMAT, playerHealth.CurrentHealth, playerHealth.MaxHealth);

        playerHealthText.SetText(healthAmountText);


        playerHealthBar.fillAmount = (float)playerHealth.CurrentHealth / playerHealth.MaxHealth;
    }


}
