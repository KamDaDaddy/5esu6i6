using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Orbiiit : MonoBehaviour
{
    //public
        //Focuses on GameObject player
        [SerializeField]
    Transform focus = default;
    
        //Sets the distance between the camera and the player
        [SerializeField, Range(1f, 20f)]
    public float distance = 5.0f;

        //Makes the camera moving with the player more smooth
        [SerializeField, Min(0f)]
    public float focusRadius = 1.0f;
    public Vector3 focusPoint;

    //private

    public void Awake()
    {
        focusPoint = focus.position;
    }

    public void UpdateFocusPoint()
    {
        //separates the location for a more precise smoothened focus point
        Vector3 targetPoint = focus.position;
    
        if(focusRadius > 0.0f)
        {
            float distance = Vector3.Distance(targetPoint, focusPoint);

                if(distance > focusRadius)
                {
                    focusPoint = Vector3.Lerp(targetPoint, focusPoint, focusRadius / distance);
                }
        }
        else
        {
            focusPoint = targetPoint;
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LateUpdate()
    {
            //Focuses on player and looks forward. It's position shifts actording to the distance from player and look direction.
        Vector3 lookDirection = transform.forward;
            transform.localPosition = focusPoint - lookDirection * distance;
        
        UpdateFocusPoint();
    }


}
