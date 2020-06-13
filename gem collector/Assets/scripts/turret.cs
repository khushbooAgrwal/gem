using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
   public GameObject claw = null;
   public Animator AnimController_gun = null;
   private bool IsShooting = false;
   private LayerMask currentmask;
   public bool Isshooting
   {
       get
       {
           return IsShooting;
       }
   }
   void Update() {
       if(Input.GetButtonDown("Fire1"))
       {
           Launchclaw();
       }
   }
   private void Launchclaw(){
       IsShooting = true;
       if(AnimController_gun != null)
       AnimController_gun.speed = 0f;

       RaycastHit hit;
       Vector3 down = transform.TransformDirection(Vector3.down);
       if(Physics.Raycast(transform.position,down,out hit,100f))
       {
            if(claw != null ){
                claw.SetActive(true);
                claw.GetComponent<claw>().clawtarget(hit.point);
            }
       }
   }
   public void CollectedObject(){
       IsShooting = false;

       if(AnimController_gun != null){
           AnimController_gun.speed = 1f;
       }
   }
}
