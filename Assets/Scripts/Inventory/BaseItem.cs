using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    public ItemScriptableObject itemSO;
    public int Amount;

    Collider2D itemCollider;

    private void Awake()
    {
        itemCollider = GetComponent<Collider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void UseItem()
    {
        //Item Use Code here.
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit");
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Inventory>().AddItem(itemSO, Amount);
            Destroy(this.gameObject);
        }
    }
}
