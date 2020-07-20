using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject StickySurface;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {

      Destroy (GetComponent<FixedJoint>());
      if(other.name == StickySurface.name){
        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = StickySurface.GetComponent<Rigidbody>();
      }






    }
    private void OnTriggerExit(Collider other){

      if(other.name != "RightHand"){
        Destroy (GetComponent<FixedJoint>());
      }

    }

}
