using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : MonoBehaviour
{

    public GameObject Player;
    public Item pictureAnklegrabber;
    public Item pictureZombieWithBlood;
    public Item pictureMutated;
    public GameObject Managers;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Managers = GameObject.FindWithTag("Managers");
    }

    // Update is called once per frame
    void Update() // een "foto" maken van het monster als je op F duwt wanneer je deze ziet
    {

        Debug.Log(Player.GetComponent<PlayerMovement>().monsterGezien);
        if (Input.GetKeyDown("f") && Player.GetComponent<PlayerMovement>().monsterGezien == "AnkleGrabber")
        {
            Managers.GetComponent<InventoryManager>().Items.Add(pictureAnklegrabber);
            Debug.Log("anklegrabber stalked");
            InventoryManager.Instance.ListItems();// update de ui direct 
            Player.GetComponent<PlayerMovement>().monsterGezien = null;
        }

        else if (Input.GetKeyDown("f") && Player.GetComponent<PlayerMovement>().monsterGezien == "Bookhead")
        {
            Managers.GetComponent<InventoryManager>().Items.Add(pictureZombieWithBlood);
            Debug.Log("bookhead stalked");
            InventoryManager.Instance.ListItems();
            Player.GetComponent<PlayerMovement>().monsterGezien = null;

        }

        else if (Input.GetKeyDown("f") && Player.GetComponent<PlayerMovement>().monsterGezien == "Zombie")
        {
            Managers.GetComponent<InventoryManager>().Items.Add(pictureMutated);
            Debug.Log("zombie stalked");
            InventoryManager.Instance.ListItems();
            Player.GetComponent<PlayerMovement>().monsterGezien = null;

        }
        
    }
}
