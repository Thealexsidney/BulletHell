using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCamera;


    [SerializeField]
    private float maxSpeed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMousePosistion(maxSpeed);

        
    }

   

    private void FollowMousePosistion(float maxSpeed)
    {
        transform.position = Vector2.MoveTowards(transform.position, GetWorldPositionFromMouse(), maxSpeed * Time.deltaTime);
        Vector3 WorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 Difference = WorldPoint - transform.position;
        Difference.Normalize();

        float RotationZ = Mathf.Atan2(Difference.y, Difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotationZ - 90);

    }



    private Vector2 GetWorldPositionFromMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }



}
