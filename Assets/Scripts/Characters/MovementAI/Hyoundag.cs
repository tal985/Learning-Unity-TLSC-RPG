using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hyoundag : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject followTarget;
    public float moveSpeed;
    private bool isMoving;
    private Animator anim;
    private const string mobName = "Hyoundag";

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;
        float distance = Vector3.Distance(followTarget.transform.position, this.transform.position);
        float x = followTarget.transform.position.x - this.transform.position.x;
        float y = followTarget.transform.position.y - this.transform.position.y;


        //Mr.Chapter (Z will always be 1)
        Vector3 targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, 1);

        //Slow movement
        if (distance <= 4 && distance > 1.25)
        {
            //(a, b, c). If c is closer to 1, it'll get closer to b, which is Mr. Chapter
            isMoving = true;
            this.transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        else if (distance <= 1.25)
        {
            Debug.Log("TRIGGERED");
            GameInfo.currentEnemy = mobName;
            SceneManager.LoadScene(2);
        }



        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("moveX", x);
        anim.SetFloat("moveY", y);
  
    }
}
