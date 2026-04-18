using UnityEngine;

public class Battery : MonoBehaviour
{
    public float batteryIncrease = 30f; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 2. Semak kalau yang langgar tu betul-betul ada tag Player1
        if (collision.CompareTag("Player1"))
        {

            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            if (player2 != null)
            {
                Flashlight p2LightScript = player2.GetComponent<Flashlight>();
                if (p2LightScript != null)
                {
                    p2LightScript.AddBattery(batteryIncrease);
                }
            }
            
            // 3. Ubat hilang!
            Destroy(gameObject);
        }
    }
}