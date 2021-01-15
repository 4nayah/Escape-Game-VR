using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
using UnityEngine.EventSystems;
public class CadenasDirectionel : MonoBehaviour
{


    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    SteamVR_Behaviour_Pose trackedObj;
    public static GameObject currentObject;
    public GameObject Cylinder1;
    public GameObject Cylinder2;
    public GameObject Cylinder3;
    public GameObject Cylinder4;
    public bool unlockChest;
    public GameObject DoorChest;
    private int i;
    private int j = 3;
    private int k = 3;
    private int l = 3;
    private int m = 3;
    private bool isHover = false;
    int currentID;
    float x;
    void Start()
    {
      currentObject = null;
      currentID = 0;
      unlockChest = false;
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
    }//END AWAKE

    // Update is called once per frame
    void Update()
    {

      // Debug.Log();
      if(unlockChest == false){
        DoorChest.GetComponent<BoxCollider>().center = new Vector3(0,2,0);
      }


      RaycastHit[] hits;
      hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for(int i=0; i<hits.Length; i++){
          RaycastHit hit = hits[i];
          int id= hit.collider.gameObject.GetInstanceID();
          if(currentID != id){
            currentID = id;
            currentObject = hit.collider.gameObject;
            if(spawn.GetStateDown(trackedObj.inputSource)){
              string name = currentObject.name;

                if(name == "Cube_0"){
                  j++;
                }
                if(name == "Cube_1"){
                  k++;
                }
                if(name == "Cube_2"){
                  l++;
                }
                if(name == "Cube_3"){
                  m++;
                }
              }//END GET STATE DOWN

              if(j==3 && k==1 && l==0 && m==2){
                unlockChest = true;
                DoorChest.GetComponent<BoxCollider>().center = new Vector3(-0.008476291f,0,-0.7016948f);


              }
          }
      }

      if(j < 4){
        Cylinder1.transform.rotation = Quaternion.Euler(-90*(j),00,00);

      }else{
        j=0;
      }


      if(k < 4){
        Cylinder2.transform.rotation = Quaternion.Euler(-90*(k),00,00);
      }else{
        k=0;
      }


      if(l < 4){
        Cylinder3.transform.rotation = Quaternion.Euler(-90*(l),00,00);
      }else{
        l=0;
      }


      if(m < 4){
        Cylinder4.transform.rotation = Quaternion.Euler(-90*(m),00,00);
      }else{
        m=0;
      }


    }// END UPDATE

    private void OnTriggerEnter(Collider other)
    {

      if (other.gameObject.tag == "LaserActive")
      {

        gameObject.GetComponent<SteamVR_LaserPointer>().thickness = 0.001f;

      }

    }
    private void OnTriggerExit(Collider other)
    {

      if (other.gameObject.tag == "LaserActive")
      {

        gameObject.GetComponent<SteamVR_LaserPointer>().thickness = 0;

      }

    }

}
