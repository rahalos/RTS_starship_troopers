using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly_camera : MonoBehaviour{

    public float panSpeed = 20f;
    public float panBorderThickness = 10f;
    public Vector2 panlimit;
    public float scrollSpeed = 20f;
    public float minz = 20f;
    public float maxz = 20f;

   
    
    

    // Update is called once per frame
    void Update()
    {

        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            pos.y += panSpeed * Time.deltaTime;

        }

        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {

            pos.y -= panSpeed * Time.deltaTime;

        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {

            pos.x += panSpeed * Time.deltaTime;

        }

        if (Input.GetKey("a") || Input.mousePosition.x <=  panBorderThickness)
        {

            pos.x -= panSpeed * Time.deltaTime;

        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.z += scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panlimit.x, panlimit.x);
 
        pos.z = Mathf.Clamp(pos.z, -panlimit.y, panlimit.y);

        transform.position = pos;

        
    }

   
}
