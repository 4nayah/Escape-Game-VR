using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
using UnityEngine.EventSystems;

public class Detect_Click : MonoBehaviour
{
    public SteamVR_Action_Boolean spawn = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    SteamVR_Behaviour_Pose trackedObj;
    public static GameObject currentObject;
    public GameObject Cylinder1;
    public GameObject Cylinder2;
    public GameObject Cylinder3;
    public GameObject Cylinder4;
    public GameObject Lock;


    public GameObject LockedTrap;
    public GameObject Canvas;
    public GameObject Key;
    public GameObject Collider;
    public float dist1;

    private int i;
    private int j = 4;
    private int k = 9;
    private int l = 5;
    private int m = 2;
    private bool isHover = false;
    int currentID;
    public Text countText;
    float x;

    void Start()
    {
      currentObject = null;
      currentID = 0;
      countText.text="CODE : "+ j.ToString()+k.ToString()+l.ToString()+m.ToString();
      Cylinder1.transform.rotation = Quaternion.Euler(-36*(j-3),-180,90);
      Cylinder2.transform.rotation = Quaternion.Euler(-36*(k-3),-180,90);
      Cylinder3.transform.rotation = Quaternion.Euler(-36*(l-3),-180,90);
      Cylinder4.transform.rotation = Quaternion.Euler(-36*(m-3),-180,90);
      Canvas.GetComponent<Canvas>().enabled = false;

      // Key.GetComponent<Collider>().enabled = false;
      // Key.GetComponent<Renderer>().enabled = false;


    }//END STARD

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_Behaviour_Pose>();
    }//END AWAKE


    void Update()
    {

      dist1 = Vector3.Distance(Canvas.transform.position, transform.position);



      RaycastHit[] hits;
      hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);





        // transform.eulerAngles = new Vector3(0, 0, 0);


        for(int i=0; i<hits.Length; i++){
          RaycastHit hit = hits[i];
          int id= hit.collider.gameObject.GetInstanceID();
          if(currentID != id){
            currentID = id;
            currentObject = hit.collider.gameObject;
            if(spawn.GetStateDown(trackedObj.inputSource)){
              string name = currentObject.name;

                if(name == "upper1"){
                  Debug.Log("upper1");
                  if(j != 9){
                    j = j+1;
                    countText.text="CODE : "+ j.ToString()+k.ToString()+l.ToString()+m.ToString();
                    Cylinder1.transform.rotation = Quaternion.Euler(-36*(j-3),-180,90);
                  }else{
                    j=-1;
                  }
                }
                if(name == "upper2"){
                  Debug.Log("upper2");
                  if(k != 9){
                    k = k+1;
                    countText.text="CODE : "+ j.ToString()+k.ToString()+l.ToString()+m.ToString();
                    Cylinder2.transform.rotation = Quaternion.Euler(-36*(k-3),-180,90);
                  }else{
                    k=-1;
                  }
                }
                if(name == "upper3"){
                  Debug.Log("upper3");
                  if(l != 9){
                    l = l+1;
                    countText.text="CODE : "+ j.ToString()+k.ToString()+l.ToString()+m.ToString();
                    Cylinder3.transform.rotation = Quaternion.Euler(-36*(l-3),-180,90);
                  }else{
                    l=-1;
                  }
                }
                if(name == "upper4"){
                  Debug.Log("upper4");
                  if(m != 9){
                    m = m+1;
                    countText.text="CODE : "+ j.ToString()+k.ToString()+l.ToString()+m.ToString();
                    Cylinder4.transform.rotation = Quaternion.Euler(-36*(m-3),-180,90);
                  }else{
                    m=-1;
                  }
                }
              }//END GET STATE DOWN


              if(j==1 && k==1 && l==1 && m==1){
                countText.text ="BREAK";

                LockedTrap.transform.rotation = Quaternion.Euler(-110f,-90f,0.1f);
                Canvas.GetComponent<Canvas>().enabled = false;
                gameObject.GetComponent<SteamVR_LaserPointer>().thickness = 0.000f;

                // Key.GetComponent<Collider>().enabled = true;
                // Key.GetComponent<Renderer>().enabled = true;



                // m=12;


                // Destroy(key, 2.0f);
                // Lock.transform.position = new Vector3(-4.0f,1.5f,0.8f);

              }
          }////END CurrentID
      }//END FOR
  }//END UPDATE

  private void OnTriggerEnter(Collider other)
  {

    if (other.gameObject.tag == "LaserActive")
    {

      gameObject.GetComponent<SteamVR_LaserPointer>().thickness = 0.001f;

    }

    if(countText.text != "BREAK" && dist1 < 1.5f){
      Canvas.GetComponent<Canvas>().enabled = true;
    }



  }
  private void OnTriggerExit(Collider other)
  {

    if (other.gameObject.tag == "LaserActive")
    {

      gameObject.GetComponent<SteamVR_LaserPointer>().thickness = 0;

    }
    if(countText.text != "BREAK" && dist1 > 1.5f){
      Canvas.GetComponent<Canvas>().enabled = false;
    }

  }

}//END SCRIPT
