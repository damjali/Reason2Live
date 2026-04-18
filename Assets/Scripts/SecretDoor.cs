using Players;
using UnityEngine;
using UnityEngine.SceneManagement;
    
public class SecretDoor : MonoBehaviour
{
    private bool p1Pass = false;
    private bool p2Pass = false;
    void OnTriggerEnter2D(Collider2D collider)
    {
        print("Something entered");
        if (collider.TryGetComponent<Player1>(out Player1 p1))
        {   
            p1Pass = true;
            Destroy(p1);
        }

        if (collider.TryGetComponent<Player2>(out Player2 p2))
        {
            p2Pass = true;
            Destroy(p2);
        }

        if (p1 && p2)
        {
            SceneManager.LoadScene("Scenes/End Page");
        }
    }
}
