using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    
    public Transform Wicher;
    public Transform ExitEnterPosition;
    public CameraMovement CameraMovement;
   
        public void Awake()
    {
        CameraMovement = FindObjectOfType<CameraMovement>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            CameraMovement.RoomTransition();
            Wicher.position = ExitEnterPosition.position;
            

        }
    }

    
}
