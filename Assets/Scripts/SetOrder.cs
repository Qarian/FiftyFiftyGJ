using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class SetOrder : MonoBehaviour
{
	SpriteRenderer sprite;

    void Start()
    {
		sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
		sprite.sortingOrder = (int)(transform.position.y * -1000);
    }
}
