using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindManager : MonoBehaviour
{
    public GameObject Managers;
    // Start is called before the first frame update
    void Start()
    {
        Managers = GameObject.FindWithTag("Managers");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGameFromManagers()
    {
        Managers.GetComponent<PlayerStats>().PlayAgain();
    }
}
