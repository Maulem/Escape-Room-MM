using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectsByColors : MonoBehaviour
{

    public GameObject redBall;
    public GameObject greenCylinder;
    public GameObject blueCube;

    public GameObject redCubeReceiver;
    public GameObject greenCubeReceiver;
    public GameObject blueCubeReceiver;

    public GameObject teleportPlane;
    
    GameObject door;
    public bool isLocked = true;

    private bool isElevated = false;
    // Start is called before the first frame update
    void Start()
    {
        door = this.gameObject;
        LockTeleportPlane();
        
    }

    private void Update()
    {
        
        if (CheckCollision(redBall.GetComponent<Collider>(), redCubeReceiver.GetComponent<Collider>()))
        {
            if (CheckCollision(greenCylinder.GetComponent<Collider>(), greenCubeReceiver.GetComponent<Collider>()))
            {
                if (CheckCollision(blueCube.GetComponent<Collider>(), blueCubeReceiver.GetComponent<Collider>()))
                {
                    if (isElevated == false){
                        ElevateDoor();
                        isElevated = true;
                        UnlockTeleportPlane();

                    }   

                }


            }
            
            
        }
        
    }

    private void UnlockTeleportPlane()
    {
        isLocked = false;
        teleportPlane.SetActive(true);
    }

    private void LockTeleportPlane()
    {
        isLocked = true;
        teleportPlane.SetActive(false);
    }


    private void ElevateDoor()
    {
        door.transform.Translate(Vector3.up * 2f);
    }

    private void LowerDoor()
    {
        door.transform.Translate(Vector3.down * 2f);
    }



    private bool CheckCollision(Collider collider1, Collider collider2)
    {
        return collider1.bounds.Intersects(collider2.bounds);
    }
}
