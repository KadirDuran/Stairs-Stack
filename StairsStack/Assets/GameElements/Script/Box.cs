using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public bool anim = false,baslangicAnim=false;
    public Vector3 box,lastBox;
    public Material material;
    void FixedUpdate()
    {
        if(anim)
        { 
           transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x,transform.position.y, transform.position.z - 1.5f), 20f * Time.deltaTime);
           if(box.z - 1.5f >= transform.position.z)
            {
                anim = false;
                baslangicAnim = true;
                transform.position = new Vector3(lastBox.x + 0.2f, lastBox.y + 0.05f, 6.5f);
            }
           
        }
        if (baslangicAnim)
        {
            gameObject.GetComponent<Renderer>().material = material;
            gameObject.tag = material.name;
            transform.position = Vector3.Lerp(transform.position, new Vector3(lastBox.x + 0.2f, lastBox.y + 0.05f, 2f), 10f * Time.deltaTime); 
           
            if ( transform.position.z < 2f)
            {
                baslangicAnim = false;
            }
        }

    }
}
