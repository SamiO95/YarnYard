using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Made by Felicia Hjärpe & Charlie Ahlstrand

    All deligates and UpdateHpMaxUI added, UpdateHpUI changed, by Charlie Ahlstrand.
 
*/

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    private PlayerCharacter player;

    void Awake()
    {
        player = FindObjectOfType<PlayerCharacter>();

        if (player != null)
        {
            player.DamagedEvent += UpdateHpUI;
            player.HpSetEvent += UpdateHpUI;
            player.MaxHpSetEvent += UpdateHpMaxUI;
            healthSlider.maxValue = player.GetPlayerMaxHealth();
        }
    }

    public void UpdateHpUI()
    {
        healthSlider.value = player.GetPlayerHealth();
    }

    public void UpdateHpMaxUI() 
    {
        healthSlider.maxValue = player.GetPlayerMaxHealth();
    }
}
