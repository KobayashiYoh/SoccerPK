using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject ballPrefab;
    float span = 5.0f;
    float countup = 0.0f;
    Vector3 generatePosistion = new Vector3(0, 1, 0);

    void GenerateBall() {
            GameObject ball = Instantiate(ballPrefab, generatePosistion, Quaternion.identity);
            Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
            if (ballRigidbody != null)
            {
                Vector3 forceDirection = new Vector3(0f, 2f, -1f).normalized;
                float forceMagnitude = 8f;
                ballRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateBall();
    }

    // Update is called once per frame
    void Update()
    {
        countup += Time.deltaTime;
        if (countup > span) {
            countup = 0;
            GenerateBall();
        }
    }
}
