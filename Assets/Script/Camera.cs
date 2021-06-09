using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObj = null;

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 vector3 = new Vector3();
        vector3.x = playerObj.transform.position.x;
        vector3.y = playerObj.transform.position.y;
        vector3.z = -10;

        transform.position = vector3;
    }
}
