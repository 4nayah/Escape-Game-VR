using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPicking : MonoBehaviour
{

    public List<GameObject> GOs;
    public GameObject Verrou;
    public GameObject Blocker;
    public GameObject Porte;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
      Porte.GetComponent<BoxCollider>().center = new Vector3(-0.3566835f,3,0.02420074f);
    }

    // Update is called once per frame
    void Update()
    {

      if(i == 100){
        Debug.Log("Ouvert");
        Verrou.transform.Rotate(0.0f, 0.0f, 0.0f);
        Porte.GetComponent<BoxCollider>().center = new Vector3(-0.3566835f,0.97f,0.02420074f);
        Blocker.GetComponent<BoxCollider>().center = new Vector3(0,18,0);
      }else if(i < 100){
        // Porte.transform.localRotation.eulerAngles.y = 180f;

      }


      if(GOs.Count == 2 && i < 100){
        Verrou.transform.Rotate(1.0f, 0.0f, 0.0f);
        i++;
      }
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Interactable"){
        GOs.Add(other.gameObject);
      }

    }
    private void OnTriggerExit(Collider other)
    {
      GOs.Remove(other.gameObject);
    }



}
