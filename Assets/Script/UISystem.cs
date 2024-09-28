using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UISystem : MonoBehaviour, IPointerClickHandler
{
    public GameObject Manager;
    InventorySystem InventorySystem;
    StorageSystem StorageSystem;

    // Start is called before the first frame update
    void Start()
    {
        InventorySystem = Manager.GetComponent<InventorySystem>();
        StorageSystem = Manager.GetComponent<StorageSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;

        //아이템 창 클릭
        if (clickedObject.tag == "ItemImage")
        {
            if(InventorySystem.Inventory_Select.activeSelf == true && InventorySystem.Inventory.activeSelf == true)
            {
                InventorySystem.Inventory_Select.transform.position = clickedObject.transform.position;
                InventorySystem.Load_Information();
                Debug.Log(clickedObject.name);
            }

            else if (StorageSystem.Slot_Select.activeSelf == true && StorageSystem.storageUI.activeSelf == true)
            {
                StorageSystem.Slot_Select.transform.position = clickedObject.transform.position;
                StorageSystem.Load_Information();
            }
            
        }
    }
}