using UnityEngine;

public class Obstacle1 : MonoBehaviour
{
    [SerializeField]
    private int _rotateSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }
}
