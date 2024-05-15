using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Transform _camera;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main.transform;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
