using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BirdMovement : MonoBehaviour
{
    [Header("Movment")]
    public Rigidbody rb;
    public float UpwardsForceMultiplier;
    public float ForwardForceMultiplier;

    [Header("Audio")]
    public AudioSource aud;
    public AudioClip jumpSound;

    private bool hasStarted = false;

    [Header("UI")]
    public TMP_Text scoreText;
    private int score = 0;
    

    private void Update()
    {
        score = (int)(Mathf.Floor((transform.position.z - 20f) / 30)) + 1;
        

        scoreText.text = "SCORE-" + score;

        if (hasStarted)
        {
            rb.AddForce(Vector3.forward * ForwardForceMultiplier);
            HandleRotation();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("pressed");

                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                rb.AddForce(Vector3.up * UpwardsForceMultiplier);

                aud.PlayOneShot(jumpSound);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                hasStarted = true;
                rb.useGravity = true;
                rb.AddForce(Vector3.up * UpwardsForceMultiplier);
                rb.AddForce(Vector3.forward * 5f, ForceMode.Impulse);

                aud.PlayOneShot(jumpSound);
            }
        }
    }

    void HandleRotation()
    {
        float xRotation = -90f - (rb.velocity.y * 3f);
        transform.rotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(0);
    }
}
