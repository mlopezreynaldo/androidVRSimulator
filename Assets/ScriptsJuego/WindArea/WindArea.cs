using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    List<Rigidbody> rigidbodiesInWindzoneList = new List<Rigidbody>();
    public Vector3 windDirection;
    public float windStrength;
    float speed;

    private void OnTriggerEnter(Collider col)
    {
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
                Vector3 position = rigid.position;                
                rigid.AddForceAtPosition(windDirection * windStrength, position);

            }
        }
    }
}
