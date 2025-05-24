using UnityEngine;
using UnityEngine.InputSystem; // Library voor het nieuwe 
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{

    [SerializeField] private string neccescaryKey;
    public string targetScene;          // Naam van de nieuwe scene
    public string targetSpawnPointName; // Naam van het teleportatiedoel in de nieuwe scene
    public AudioSource src;
    public AudioClip sfx1;
    public void Start()
    {
        if (src == null)
        {
            src = GetComponent<AudioSource>();

        }
    }

    public void LoadScene()// nodig voor juiste teleportatie
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject inventoryUI = GameObject.FindGameObjectWithTag("Player");

        GameObject managers = GameObject.FindGameObjectWithTag("Managers");
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        //GameObject menuUI = GameObject.FindGameObjectWithTag("MenuUI");
        GameObject healthUI = GameObject.FindGameObjectWithTag("HealthUI");
        //GameObject hideInventory = GameObject.FindGameObjectWithTag("HideInventory");
        //GameObject showInventory = GameObject.FindGameObjectWithTag("ShowInventory");
        GameObject toggleInventory = GameObject.FindGameObjectWithTag("ToggleInventory");



        DontDestroyOnLoad(managers);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(player);


        player.SetActive(true);
        managers.SetActive(true);
        canvas.SetActive(true);
        inventoryUI.SetActive(true);
        toggleInventory.SetActive(true);

        
    }

    public void OnMouseDown()
    {

        SoundEffects(); // Speel het geluid van de deur af bij interactie
        if (Mouse.current.leftButton.wasPressedThisFrame) // Checken of de linker muisknop is ingedrukt
        { 
            string equippedItem = EquippedItemManager.Instance.EquippedItemName; 
            if (equippedItem == neccescaryKey) // Checken of de seler de juiste sleutel heeft
            {
                //Stel de spawnpointnaam in voordat de scene wordt geladen
                SpawnManager.spawnPointName = targetSpawnPointName;

                //Laad de nieuwe scene
                Debug.Log("travel to " + targetScene + " door " + targetSpawnPointName);
                SceneManager.LoadScene(targetScene);

                LoadScene();

            }
            else // Als de speler geen of de verkeerde sleutel heeft een gepaste foutmelding geven 
            {
                if (equippedItem == null) 
                {
                    Debug.Log(" - TIP : " + neccescaryKey);

                }
                else
                {
                    Debug.Log("You don't have the necessary key equipped! , you have " + equippedItem + " and you need key " + neccescaryKey);

                }
            }

        }
    }

    private void Update()
    {
        if (Input.GetKey("f") && EquippedItemManager.Instance.tag == gameObject.tag)
        {
            OnMouseDown();

            
        }
    }

    public void SoundEffects()
    {
        src.clip = sfx1;
        src.volume = 1;
        src.Play();


      


    }
}
