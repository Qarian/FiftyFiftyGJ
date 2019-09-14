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

    void Update()
    {
		sprite.sortingOrder = (int)(transform.position.y * -1000);
    }
}
