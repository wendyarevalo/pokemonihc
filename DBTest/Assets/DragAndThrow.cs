using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndThrow : MonoBehaviour
{

    bool draging = false;
    float distance;
    public float ThrowSpeed;
    public float ArchSpeed;
    public float Speed;

    private void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        draging = true;
    }

    public void OnMouseUp()
    {
        this.GetComponent<Rigidbody>().useGravity = true;
        this.GetComponent<Rigidbody>().velocity += this.transform.forward * ThrowSpeed;
        this.GetComponent<Rigidbody>().velocity += this.transform.up * ArchSpeed;
        draging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (draging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = Vector3.Lerp(this.transform.position, rayPoint, Speed * Time.deltaTime);
        }
    }
}
