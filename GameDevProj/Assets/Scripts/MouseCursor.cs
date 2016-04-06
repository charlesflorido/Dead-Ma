using UnityEngine;
using System.Collections;

public class MouseCursor : MonoBehaviour {

	
    
    // Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        Vector3 pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "zombieCollider")
        {
            EnemyCollider eCol = coll.gameObject.GetComponent<EnemyCollider>();
            eCol.ShowHealth(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "zombieCollider")
        {
            EnemyCollider eCol = coll.gameObject.GetComponent<EnemyCollider>();
            eCol.ShowHealth(false);
        }
    }

}
