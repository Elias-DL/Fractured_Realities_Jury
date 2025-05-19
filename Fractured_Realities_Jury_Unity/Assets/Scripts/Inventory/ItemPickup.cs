using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class ItemPickup : MonoBehaviour
{
    public GameObject MainCamera; public Item Item;
    public TextMeshProUGUI txtTips;
    private bool itemPickedUp = false;
    public void Pickup()
    {
        // Clear the itemSeen in player movement
        

        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        Destroy(gameObject);
        InventoryManager.Instance.Add(Item);
        InventoryManager.Instance.ListItems();
        InventoryManager.Instance.ListItems(); // Ui refresh
        
    }

    private void OnMouseDown()
    {
       if (gameObject.GetComponent<MeshRenderer>().enabled == true)
        {
            Pickup();

        }
    }


    private void Update()
    {
        //Debug.Log(Item.name);
        if (Input.GetKeyDown(KeyCode.R) && EquippedItemManager.Instance.EquippedItemName == Item.name)
        {
            unequip();
        }
    }
    void unequip()
    {
        MainCamera = GameObject.FindWithTag("MainCamera");
        int defaultLayer = LayerMask.NameToLayer("Default"); MainCamera.layer = defaultLayer; 
        EquippedItemManager.Instance.ClearEquippedItem();
       
        Destroy(gameObject);
        InventoryManager.Instance.Add(Item);

        InventoryManager.Instance.ListItems(); 
    }
}