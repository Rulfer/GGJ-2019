using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject img_can_pick_up = null;
    public GameObject held_Object = null;
    public List<GameObject> objects_to_pick_up = new List<GameObject>();

    [SerializeField] private float held_y_pos_modifier = 0.1f;
    [SerializeField] private float thrust = 10f;
    [SerializeField] private float up_Thrust = 0.5f;

    static public GameObject toRemove = null;

    private void Update()
    {

        if (toRemove != null)
        {
            if (objects_to_pick_up.Contains(toRemove))
            {
                objects_to_pick_up.Remove(toRemove);
                Debug.Log("Removed destroyed object " + toRemove.transform.name + " from my list");
            }
        }

        if(held_Object != null)
        {
            if (img_can_pick_up.activeSelf)
                img_can_pick_up.SetActive(false);

            return;
        }

        if(objects_to_pick_up.Count > 0)
            img_can_pick_up.SetActive(true);
        else
            img_can_pick_up.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag.Equals(ENUMS.tag_throwable))
        {
            objects_to_pick_up.Add(collision.gameObject);
        }
        //else if(collision.transform.tag.Equals(ENUMS.tag_throwableChild))
        //{
        //    objects_to_pick_up.Add(collision.transform.parent.gameObject);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(objects_to_pick_up.Contains(collision.gameObject))
        {
            objects_to_pick_up.Remove(collision.gameObject);
            //Debug.Log("Remove " + collision.gameObject.name + " from list");
        }
    }

    public void GrabItem(Rigidbody2D rigid)
    {
        if (objects_to_pick_up.Count <= 0)
            return;


        if (objects_to_pick_up.Count == 1)
            held_Object = objects_to_pick_up[0];
        else
        {
            float currentLowest = 10000;

            for(int i = 0; i < objects_to_pick_up.Count; i++)
            {
                float distance = Vector2.Distance(this.transform.position, objects_to_pick_up[i].transform.position);

                if (distance < currentLowest)
                {
                    if(objects_to_pick_up[i] != null)
                    {
                        held_Object = objects_to_pick_up[i];
                        currentLowest = distance;
                    }
                }
            }
        }


        rigid.mass = held_Object.GetComponent<Rigidbody2D>().mass;
        rigid.simulated = true;
        held_Object.GetComponent<Rigidbody2D>().simulated = false;
        held_Object.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        held_Object.transform.parent = this.transform;
        held_Object.transform.localPosition = new Vector2(0, held_y_pos_modifier);
    }

    public void ThrowItem(bool left)
    {
        objects_to_pick_up.Remove(held_Object);
        held_Object.transform.parent = null;
        //held_Object.GetComponent<Rigidbody2D>().AddForce(held_Object.transform.up * thrust, ForceMode2D.Impulse);
        if(left)
            held_Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, up_Thrust) * thrust, ForceMode2D.Impulse);
        else
            held_Object.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, up_Thrust) * thrust, ForceMode2D.Impulse);

        held_Object.GetComponent<Rigidbody2D>().simulated = true;

        held_Object = null;
    }
}
