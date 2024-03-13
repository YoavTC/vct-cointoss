using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinToss : MonoBehaviour
{
    [SerializeField] private Transform sideA, sideB;
    
    [SerializeField] private float launchForce, spinForce;
    private Rigidbody rb;
    public bool tossed = false;

    [SerializeField] private GameObject information;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) Toss();
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(0);
        if (Input.GetKeyDown(KeyCode.H))
        {
            information.SetActive(false);
        }
    }

    private void Toss()
    {
        tossed = true;
        rb.useGravity = true;
        rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        

        // Apply spin
        //Vector3 spinDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        float spinX = GetRandomRotation();
        float spinY = GetRandomRotation();
        float spinZ = GetRandomRotation();
        Vector3 spinDirection = new Vector3(spinX, spinY, spinZ).normalized;
        rb.AddTorque(spinDirection * spinForce, ForceMode.Impulse);
    }

    private float GetRandomRotation()
    {
        float newRotation = Random.Range(-1f, 1f);

        if (Mathf.Abs(newRotation) < 0.3f)
        {
            newRotation = Mathf.Sign(newRotation) * 0.3f;
        }

        return newRotation;
    }
}