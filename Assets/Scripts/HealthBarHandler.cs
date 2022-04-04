using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    private Image HealthBarImage;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.DamageEvent += SetHealthBarValue;
        player.UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealthBarValue(float value)
    {
        Debug.Log(value);
        HealthBarImage.fillAmount = value;
        if (value < 0.2)
        {
            HealthBarImage.color = Color.red;
        }
        else if (value < 0.5)
        {
            HealthBarImage.color = new Color(1f, 0.5f, 0f);
        }
        else if (value < 0.8)
        {
            HealthBarImage.color = Color.yellow;
        }
        else
        {
            HealthBarImage.color = Color.green;
        }
    }

    public float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }
}
