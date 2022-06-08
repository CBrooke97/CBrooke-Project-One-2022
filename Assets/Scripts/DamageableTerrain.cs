using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableTerrain : MonoBehaviour
{
    [SerializeField] private Element element;
    [SerializeField] private Collider2D terrainCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompareElement(Element _element)
    {
        Debug.Log(string.Format("{0} + {1}", _element, element));
        if (element == Element.Fire && _element == Element.Water)
            StartCoroutine(RemoveTerrain());

        else if (element == Element.Leaf && _element == Element.Fire)
            StartCoroutine(RemoveTerrain());


        else if (element == Element.Water && _element == Element.Leaf)
            StartCoroutine(RemoveTerrain());
    }

    private IEnumerator RemoveTerrain()
    {
        print("Deleting Terrain");
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);

    }
}
