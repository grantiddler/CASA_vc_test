using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{   
    void Update()
    {
    transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}
