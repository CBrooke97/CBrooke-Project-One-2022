using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstralusBarHandler : MonoBehaviour
{
    private Image astralusBarImage;
    // Start is called before the first frame update
    void Start()
    {
        astralusBarImage = GetComponent<Image>();
        Debug.Log(astralusBarImage);
        Player _player = GameObject.Find("Player").GetComponent<Player>();
        _player.AstralusEvent += SetAstralusBarValue;
        _player.OnAstralusUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAstralusBarValue(float value)
    {
        Debug.Log(value + "Astralus");
        astralusBarImage.fillAmount = value;
    }

    public float GetAstralusBarValue()
    {
        return astralusBarImage.fillAmount;
    }
}
