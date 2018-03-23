using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    List<Rigidbody> rigidbodiesInWindzoneList = new List<Rigidbody>();
    Vector3 windDirection = new Vector3(20f,0f,0f);
    public float windStrength;

    private void OnTriggerEnter(Collider col)
    {

        Debug.Log("Entro en la zona de viento");

        Transform[] allChildren = col.gameObject.GetComponentsInChildren<Transform>();
        List<GameObject> childObjects = new List<GameObject>();
        foreach (Transform child in allChildren)
        { 
            childObjects.Add(child.gameObject);
            Debug.Log(child.gameObject.tag);
        }


        //if(col.gameObject.tag == ""){
        
          //  Debug.Log("Tag");
        
       // }
        

        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();

        if (objectRigid != null){
            rigidbodiesInWindzoneList.Add(objectRigid);
        }

    }

    private void OnTriggerExit(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();

        if (objectRigid != null){

            rigidbodiesInWindzoneList.Remove(objectRigid);

        }
    }

    private void FixedUpdate()
    {
        if (rigidbodiesInWindzoneList.Count > 0)
        {
            foreach (Rigidbody rigid in rigidbodiesInWindzoneList)
            {
                rigid.AddForce(windDirection * windStrength);
            }
        }
    }
}
