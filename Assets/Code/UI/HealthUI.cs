using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Slider healthSlider;
    private PlayerCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCharacter>();
        if (player != null)
        {
            player.DamagedEvent += UpdateHealthUI;
            healthSlider.maxValue = player.GetPlayerMaxHealth();
        }
    }

    public void UpdateHealthUI()
    {
        healthSlider.value = player.GetPlayerHealth();
    }
}
