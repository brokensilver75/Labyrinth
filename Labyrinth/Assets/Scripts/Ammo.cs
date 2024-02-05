using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public void RaiseAmmo(Gun gun)
    {
        gun.raiseAmmo();//GetComponent<Gun>().raiseAmmo();
    }
}
