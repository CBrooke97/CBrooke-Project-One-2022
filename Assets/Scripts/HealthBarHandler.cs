using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    private Image healthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        healthBarImage = GetComponent<Image>();
        Player _player = GameObject.Find("Player").GetComponent<Player>();
        _player.DamageEvent += SetHealthBarValue;
        _player.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealthBarValue(float value)
    {
        //Debug.Log(value);
        healthBarImage.fillAmount = value;
        if (value < 0.15)
        {
            healthBarImage.color = Color.red;
        }
        else if (value < 0.3)
        {
            healthBarImage.color = new Color(1f, 0.5f, 0f);
        }
        else if (value < 0.6)
        {
            healthBarImage.color = Color.yellow;
        }
        else
        {
            healthBarImage.color = Color.green;
        }
    }

    public float GetHealthBarValue()
    {
        return healthBarImage.fillAmount;
    }
}
