using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureCheck : MonoBehaviour
{

    public GameObject Key;
    public GameObject imgAnkle;
    public GameObject imgBookHead;
    public GameObject imgZombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (imgAnkle.GetComponent<MeshRenderer>().enabled == true && imgBookHead.GetComponent<MeshRenderer>().enabled == true && imgZombie.GetComponent<MeshRenderer>().enabled) // De key zichtbaar maken als je alle fotos hebt opgehanden
        {
            if (Key != null)
            {
                Key.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
