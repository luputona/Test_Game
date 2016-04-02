using UnityEngine;
using System.Collections;

public class StoreSlot : MonoBehaviour {

    private ItemStore itemstore;
    public int id;

	// Use this for initialization
	void Start () 
    {
        itemstore = GameObject.Find("Inventory").GetComponent<ItemStore>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

  


}
