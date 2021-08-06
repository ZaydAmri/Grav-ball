using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Camera camera;
    public Transform ballParent;
    public bool UiCamera = false;
    float distance;
    public void Start()
    {
        camera.aspect = 16f / 9f;
        if (!UiCamera)
        {
            distance = this.transform.position.x - ballParent.position.x;
        }
        
        
    }

    void Update()
    {
        if (!UiCamera)
        {
            this.transform.position = new Vector3(ballParent.position.x + distance, 0, -10);
        }
        
    }


}
