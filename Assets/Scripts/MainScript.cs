using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Lock1;
    keys locker1;
    public GameObject Lock2;
    keys locker2;
    public GameObject Lock3;
    keys locker3;
    public GameObject EndFireplaceDoor;




    void Start()
    {
      locker1 = Lock1.GetComponent<keys>();
      locker2 = Lock2.GetComponent<keys>();
      locker3 = Lock3.GetComponent<keys>();
    }

    // Update is called once per frame
    void Update()
    {
      // EndFireplaceDoor.transform.position = new Vector3(EndFireplaceDoor.transform.position.x, 0.9f , EndFireplaceDoor.transform.position.z);



      if(locker1.lock1isActive == true && locker2.lock2isActive == true && locker3.lock3isActive == true || Input.GetKey(KeyCode.A)){
        // EndFireplaceDoor.transform.position = new Vector3(EndFireplaceDoor.transform.position.x, 2 , EndFireplaceDoor.transform.position.z);
        EndFireplaceDoor.transform.Translate(Vector3.up * Time.deltaTime * 0.5f, Space.World);

      }


    }
}
