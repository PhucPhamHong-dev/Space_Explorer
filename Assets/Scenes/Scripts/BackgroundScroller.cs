using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float speed = 2f; 
    private float height;
    private Vector3 startPos;
    private GameObject cloneBg;

    void Start()
    {

        startPos = transform.position;
        

        height = GetComponent<SpriteRenderer>().bounds.size.y;


        cloneBg = Instantiate(gameObject);
        

        Destroy(cloneBg.GetComponent<BackgroundScroller>());
        

        cloneBg.transform.position = new Vector3(startPos.x, startPos.y + height, startPos.z);
    }

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);
        cloneBg.transform.Translate(Vector3.down * speed * Time.deltaTime);



        if (transform.position.y < startPos.y - height)
        {
            transform.position = new Vector3(startPos.x, cloneBg.transform.position.y + height, startPos.z);
        }
        

        if (cloneBg.transform.position.y < startPos.y - height)
        {
            cloneBg.transform.position = new Vector3(startPos.x, transform.position.y + height, startPos.z);
        }
    }
}