using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starBackerScript : MonoBehaviour
{
    public Transform backer;

    private float curX = 0f;
    private float lastX = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curX = this.transform.position.x;

        this.transform.position += Vector3.right * -Time.deltaTime;

        if (curX < 46 && lastX >= 46)
        {
            Transform backerInstance = Instantiate(
                backer,
                new Vector3(this.transform.position.x + 28f, 0, 10),
                Quaternion.identity
            );
        }
        if (curX < 15)
        {
            Destroy(this.gameObject);
        }

        lastX = curX;
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Border")
        {
            Transform backerInstance = Instantiate (
                backer,
                new Vector3(this.transform.position.x + 15f, 0, 0),
                Quaternion.identity
            );

            
        }
    }*/

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("triggerExit");
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
            Debug.Log("border TriggerExit");
        }
    }*/
}
