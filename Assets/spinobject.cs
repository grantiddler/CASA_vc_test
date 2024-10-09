using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinobject : MonoBehaviour
{
    public float degrees = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 10 * Time.deltaTime,0, Space.World);
    }
}
