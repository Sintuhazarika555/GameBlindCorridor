using UnityEngine;

public class Obstacle3 : MonoBehaviour
{
    [SerializeField]
    private int _rotateSpeed = 100;

    [SerializeField]
    private Transform _pivotPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(_pivotPoint.position, Vector3.forward, _rotateSpeed * Time.deltaTime);
    }
}
