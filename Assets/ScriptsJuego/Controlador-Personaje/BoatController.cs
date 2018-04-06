using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour
{
  public PropellerBoats ship;
  bool forward = true;

  void Update()
  {

        if (forward)
        {
            ship.ThrottleUp();
        }


  }

}
