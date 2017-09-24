using UnityEngine;

public class DestroyArea : MonoBehaviour
{
    Spaceship spaceship;
    void OnTriggerExit2D(Collider2D c)
    {
        Destroy(c.gameObject);
    }
}