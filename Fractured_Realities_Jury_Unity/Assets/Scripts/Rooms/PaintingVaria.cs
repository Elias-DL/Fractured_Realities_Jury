using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingVaria : MonoBehaviour
{
    public GameObject Painting; // Schilderj component in de inspector
    public string imagePainting; // Naam van het schilderij
    public GameObject GameObjectPainting; // Gameobject van het schilderij
    // Start is called before the first frame update
    void Start()
    {
        // Controleren of het schilderij al eerder is opgehangen
        if (PlayerPrefs.HasKey(imagePainting + "Gevonden")) 
        {
            Painting.SetActive(true);
        }
    }
    private void OnMouseDown() // Als er op het kader wordt gedrukt
    {
        
        // Checken of de speler het juiste schilderij vast heeft
        if (EquippedItemManager.Instance.EquippedItemName == imagePainting) 
        {
            // Het kader opvullen met het schilderij
            Painting.SetActive(true);
         
            // Het schilderij verwijderen 
            GameObjectPainting = GameObject.FindWithTag("Painting" + imagePainting);
            Destroy(GameObjectPainting); 
            EquippedItemManager.Instance.ClearEquippedItem();

            // Playerprefs variabelen aanmaken
            PlayerPrefs.SetString(imagePainting + "Gevonden", "true"); 
            PlayerPrefs.Save();


        }
    }
}