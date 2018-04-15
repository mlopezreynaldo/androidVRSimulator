using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    private List<Rigidbody> rigidbodiesInWindzoneList = new List<Rigidbody>();
    public Vector3 windDirection;
    public float windStrength = 0f;


    public float WindStrength { get; set; }
    public Vector3 WindDirection { get; set; }

    public void WindSet(Vector3 windDirection, float windStrength){
        this.windDirection = windDirection;
        this.windStrength = windStrength;
    }


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
