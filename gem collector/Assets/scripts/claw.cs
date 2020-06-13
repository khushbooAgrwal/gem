using System.Collections;
using UnityEngine;

public class claw : MonoBehaviour
{
   public Transform Origin = null;
   public float speed = 4f;
   public turret turretScript = null ;
   public int GemValue = 100;
   private Vector3 target;
   private GameObject childobject =null;
   private LineRenderer lineRenderer = null;
   private bool Isgemhit = false;
   private bool Isretracting = false;
   void Awake() {
       lineRenderer = GetComponent<LineRenderer>();
   }
    void Update() {
       float step = speed * Time.deltaTime;
       transform.position = Vector3.MoveTowards(transform.position,target,step);
       lineRenderer.SetPosition(0,Origin.position);
       lineRenderer.SetPosition(1,Origin.position);

       if(transform.position == Origin.position && Isretracting && turretScript != null){
           turretScript.CollectedObject();
           if(Isgemhit){
               Isgemhit = false;
           }
           if(childobject != null){
               Destroy(childobject);
           }
           gameObject.SetActive(false);
           Isretracting = false;
       }
   }
   public void clawtarget(Vector3 targetpos){
       target = targetpos;
   }
   void OnTriggerEnter(Collider other) {
       if(Isretracting){
           Isretracting = true;
           target = Origin.position;
           if(other.gameObject.CompareTag("Gem"))
           Isgemhit = true;
           if(!other.gameObject.CompareTag("Barrier")){
               childobject = other.gameObject;
               other.transform.SetParent(this.transform);
           }
       }
   }
}
