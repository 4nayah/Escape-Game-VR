using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keys : MonoBehaviour
{


    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject keyFake1;
    public GameObject keyFake2;
    public GameObject keyFake3;
    public bool lock1isActive = false;
    public bool lock2isActive = false;
    public bool lock3isActive = false;
    // Start is called before the first frame update
    void Start()
    {
      keyFake1.GetComponent<Renderer>().enabled = false;
      keyFake2.GetComponent<Renderer>().enabled = false;
      keyFake3.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(lock1isActive == true && lock2isActive == true && lock3isActive == true){
        // Debug.Log("fini");
      }


    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.name == key1.name)
      {
        key1.GetComponent<Renderer>().enabled = false;
        keyFake1.GetComponent<Renderer>().enabled = true;
        lock1isActive = true;
      }


      if (other.gameObject.name == key2.name)
      {
        key2.GetComponent<Renderer>().enabled = false;
        keyFake2.GetComponent<Renderer>().enabled = true;
        lock2isActive = true;
      }


      if (other.gameObject.name == "key3")
      {
        key3.GetComponent<Renderer>().enabled = false;
        keyFake3.GetComponent<Renderer>().enabled = true;
        lock3isActive = true;
      }


    }
}
