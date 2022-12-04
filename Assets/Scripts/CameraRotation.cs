using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotationVelocity = 50f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalAxis = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, _rotationVelocity * HorizontalAxis * Time.deltaTime);
    }
}
