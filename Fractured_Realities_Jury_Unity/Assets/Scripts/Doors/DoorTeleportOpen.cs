using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTeleport : MonoBehaviour
{
    public string targetScene;          // Naam van de nieuwe scene
    public string targetSpawnPointName; // Naam van het teleportatiedoel in de nieuwe scene



    public void Start()
    {

    }
    public void LoadScene() // nodig voor juiste teleportatie
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject inventoryUI = GameObject.FindGameObjectWithTag("Player");

        GameObject managers = GameObject.FindGameObjectWithTag("Managers");
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        GameObject menuUI = GameObject.FindGameObjectWithTag("MenuUI");
        GameObject healthUI = GameObject.FindGameObjectWithTag("HealthUI");
        
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



    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            // Stel de spawnpointnaam in voordat de scene wordt geladen
            SpawnManager.spawnPointName = targetSpawnPointName;

            // Laad de nieuwe scene
            //Debug.Log("travel to " + targetScene + " door " + targetSpawnPointName);
            SceneManager.LoadScene(targetScene);

            LoadScene();



        }
    }
}
