using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatTriggerManager : MonoBehaviour
{
    private Animation anim;

    private void Start()
    {
        //anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "MC_Player")
        {
            Debug.Log("Collided with MC!");
            //anim.Play("fade_out");
            SceneManager.LoadScene(2);
        }


    }
}
