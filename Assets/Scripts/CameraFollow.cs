using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float minX, maxX, minY, maxY;
    public float smoothSpeed = 5f;

    private float camHeight;
    private float camWidth;

    void Start()
    {
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }

        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;

        transform.position = GetClampedPosition(); // snap at start
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPos = GetClampedPosition();

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smoothSpeed * Time.deltaTime
        );
    }

    Vector3 GetClampedPosition()
    {
        float minClampX = minX + camWidth;
        float maxClampX = maxX - camWidth;

        float minClampY = minY + camHeight;
        float maxClampY = maxY - camHeight;

        // 🔥 SAFETY: if bounds are invalid, fallback to target position
        float x = (minClampX > maxClampX) ? target.position.x :
                  Mathf.Clamp(target.position.x, minClampX, maxClampX);

        float y = (minClampY > maxClampY) ? target.position.y :
                  Mathf.Clamp(target.position.y, minClampY, maxClampY);

        return new Vector3(x, y, -10f);
    }
}