using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinToss : MonoBehaviour
{
    [SerializeField] private Transform sideA, sideB;
    [SerializeField] private GameObject information;
    
    [SerializeField] private float launchForce, spinForce;
    private Rigidbody rb;
    public bool tossed = false;


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
        float spinX = GetRandomRotation();
        float spinY = Mathf.Min(GetRandomRotation(), 0.5f);
        float spinZ = GetRandomRotation();
        
        Vector3 spinDirection = new Vector3(spinX, spinY, spinZ).normalized;
        rb.AddTorque(spinDirection * spinForce, ForceMode.Impulse);
        
        Debug.Log("XR: " + spinX);
        Debug.Log("YR: " + spinY);
        Debug.Log("ZR: " + spinZ);
        Debug.Log("------------------");
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