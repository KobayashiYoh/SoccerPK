using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private Collider ballCollider;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        ballCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // クリック位置をローカル座標系に変換
                    Vector3 clickPosition = transform.InverseTransformPoint(hit.point);
                    Vector2 clickPosition2D = new Vector2(clickPosition.x, clickPosition.y);
                    Vector2 ballPosition2D = new Vector2(transform.position.x, transform.position.y);
                    float diffDistance = (clickPosition2D - ballPosition2D).magnitude;
                    Debug.Log("diffDistance: " + diffDistance);
                    float shootPower = Mathf.Pow(1 / diffDistance, 2);
                    if (shootPower > 189) {
                        shootPower = 189;
                    }
                    Vector3 shootDirection = clickPosition.normalized;
                    if (shootDirection.z < 0) {
                        shootDirection = -shootDirection;
                    }
                    ballRigidbody.AddForce(shootDirection * shootPower * 5, ForceMode.Impulse);
                }
            }
        }
    }
}
