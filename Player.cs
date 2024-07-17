using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.7f;
    private float gravity = 9.81f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * speed;
        velocity.y -= gravity;

        velocity = transform.transform.TransformDirection(velocity);
        characterController.Move(velocity * Time.deltaTime);
    }
}
