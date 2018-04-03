using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour {

    List<Rigidbody> rigidbodiesInWindzoneList = new List<Rigidbody>();
    Vector3 windDirection = new Vector3(20f,0f,0f);
    public float windStrength;
    public Transform target;

    // Angular speed in radians per sec.
    float speed;

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

                Vector3 targetDir = target.position - rigid.position;
                float step = speed * Time.deltaTime;

                Vector3 newDir = Vector3.RotateTowards(rigid.position, targetDir, step, 0.0f);
                Debug.DrawRay(transform.position, newDir, Color.red);

                // Move our position a step closer to the target.
                rigid.rotation = Quaternion.LookRotation(newDir);
                //rigid.AddForce(windDirection * windStrength);
                //target.LookAt(Vector3.zero);
                //transform.LookAt(Vector3.zero);
            }
        }
    }
}
