using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputs m_playerInputs;
    private Vector2 m_moveInput;

    private void Awake()
    {
        m_playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        m_playerInputs.Enable();
    }

    private void OnDisable()
    {
        m_playerInputs.Disable();
    }

    private void Update()
    {
        m_moveInput = m_playerInputs.Player.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMoveInput() { return m_moveInput; }
}
