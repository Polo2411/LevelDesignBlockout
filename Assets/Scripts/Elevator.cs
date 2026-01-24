using UnityEngine;
using UnityEngine.InputSystem;

public class Elevator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float stepDown = 10f;  
    [SerializeField] private float speed = 3f;

    private Vector3 targetPos;
    private bool isMoving;

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        if (!isMoving && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            targetPos += Vector3.down * stepDown;
            isMoving = true;
        }

        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.0001f)
            {
                transform.position = targetPos;
                isMoving = false;
            }
        }
    }
}

