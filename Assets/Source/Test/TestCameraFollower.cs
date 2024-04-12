using UnityEngine;

public class TestCameraFollower : MonoBehaviour
{
    private void Update()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
    }
}
