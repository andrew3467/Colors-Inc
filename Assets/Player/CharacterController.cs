using UnityEngine;

public class CharacterController : MonoBehaviour {
    [SerializeField]
    float moveSpeed = 1.5f;
    [SerializeField]
    float sensitivity = 1.0f;
    
    [SerializeField]
    UnityEngine.CharacterController controller;
    [SerializeField]
    Camera camera;
    [SerializeField]
    Vector2 pitchConstraints;


    Vector3 velocity = Vector3.zero;

    float yaw = 0, pitch = 0;
    

    void FixedUpdate() {
        Move();
        Rotate();
    }

    void Move() {
        Vector3 direction = Vector3.zero;
        direction += transform.forward * Input.GetAxisRaw("Vertical");
        direction += transform.right * Input.GetAxisRaw("Horizontal");
        direction.Normalize();
        
        controller.Move(direction * moveSpeed);
    }

    void Rotate() {
        if (!Input.GetMouseButton(2)) { return;}

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        yaw += Input.GetAxisRaw("Mouse X") * sensitivity;
        pitch -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        
        pitch = Mathf.Clamp(pitch, pitchConstraints.x, pitchConstraints.y);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
