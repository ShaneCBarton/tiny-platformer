using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float m_jumpHeight;
    [SerializeField] private float m_moveSpeed;

    private PlayerInput m_playerInput;
    private CharacterController m_characterController;
    private Vector3 m_playerVelocity;
    private bool m_isGrounded;
    private bool m_hasRequiredComponents;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_characterController = GetComponent<CharacterController>();
        m_hasRequiredComponents = m_playerInput != null && m_characterController != null;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!m_hasRequiredComponents) { return; }
        m_isGrounded = m_characterController.isGrounded;

        if (m_isGrounded && m_playerVelocity.y < 0) { m_playerVelocity.y = 0; }

        Vector3 movement = new Vector3(m_playerInput.GetMoveInput().x, 0, m_playerInput.GetMoveInput().y);
        //movement = Vector3.ClampMagnitude(movement, 1f);
        m_playerVelocity.y += Physics.gravity.y * Time.deltaTime;

        Vector3 finalMovement = (movement * m_moveSpeed) + (m_playerVelocity.y * Vector3.up);
        m_characterController.Move(finalMovement * Time.deltaTime);
    }
}
