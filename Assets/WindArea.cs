using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    List<Rigidbody> rigidbodiesInWindzoneList = new List<Rigidbody>();
    Vector3 windDirection = new Vector3(20f,0f,0f);
    public float windStrength;

    private void OnTriggerEnter(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();

        if (objectRigid != null)
            rigidbodiesInWindzoneList.Add(objectRigid);
    }

    private void OnTriggerExit(Collider col)
    {
        Rigidbody objectRigid = col.gameObject.GetComponent<Rigidbody>();

        if (objectRigid != null)
            rigidbodiesInWindzoneList.Remove(objectRigid);
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
