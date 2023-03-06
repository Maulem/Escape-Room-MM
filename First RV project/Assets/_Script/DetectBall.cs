using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject cube;
    public GameObject teleportPlane;
    public GameObject explosion;
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
        if (ball != null && cube != null)
        {
            if (CheckCollision(ball.GetComponent<Collider>(), cube.GetComponent<Collider>()))
            {
                if (isElevated == false){
                    // ElevateDoor();
                    explosion.SetActive(true);
                    Destroy(ball);
                    Destroy(cube);
                    Destroy(door);
                    isElevated = true;
                    UnlockTeleportPlane();

                }
                
            }
            // else{
                // if (isElevated == true){
                //     LowerDoor();
                //     LockTeleportPlane();
                //     isElevated = false;
                // }
            // }
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


