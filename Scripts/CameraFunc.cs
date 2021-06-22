using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunc : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.position = new Vector3(Target.position.x, Target.position.y + 1, -10);
    }
}
