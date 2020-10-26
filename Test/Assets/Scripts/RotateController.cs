using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateController : MonoBehaviour
{
    [SerializeField] public GameObject otherObject;
    [SerializeField] private GameObject ball;

    Quaternion orRpt;
    float horizontal;
    float vertikal;
    float mousSens = 1;
    float horizontal2;
    float vertikal2;
    float mousSens2 = 0.03f;
    float ratioT = 0.1f;
    float limit = 10;

    public const int SLIDELAYER = 8;
    public const int FUNNULLAYER = 9;

    void Start()
    {
        orRpt = transform.rotation;
    }

    void Update()
    {
        horizontal += Input.GetAxis("Mouse X") * mousSens;
        vertikal += Input.GetAxis("Mouse Y") * mousSens;
        vertikal = Mathf.Clamp(vertikal, -limit, limit);
        horizontal = Mathf.Clamp(horizontal, -limit, limit);
        Quaternion rotationY = Quaternion.AngleAxis(horizontal, Vector2.up);
        Quaternion rotationX = Quaternion.AngleAxis(vertikal, Vector2.right);
        transform.rotation = Quaternion.Slerp(transform.rotation, orRpt * rotationY * rotationX, Mathf.PingPong(Time.time, ratioT));

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                horizontal2 += touch.deltaPosition.x * mousSens2;
                vertikal2 += touch.deltaPosition.y * mousSens2;
                horizontal2 = Mathf.Clamp(horizontal2, -limit, limit);
                vertikal2 = Mathf.Clamp(vertikal2, -limit, limit);
                Quaternion rotationY2 = Quaternion.AngleAxis(horizontal2, Vector3.up);
                Quaternion rotationX2 = Quaternion.AngleAxis(vertikal2, Vector3.right);
                transform.rotation = Quaternion.Slerp(transform.rotation, orRpt * rotationY2 * rotationX2, Mathf.PingPong(Time.time, ratioT));
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (gameObject.layer == SLIDELAYER)
        {
            otherObject.transform.position = new Vector3(transform.position.x, transform.position.y - 7, transform.position.z - 10);
        }
        if (gameObject.layer == FUNNULLAYER)
        {
            otherObject.transform.position = new Vector3(transform.position.x, transform.position.y - 12, transform.position.z);
        }
    }
}
