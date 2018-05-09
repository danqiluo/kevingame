using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public Entity targetEntity;
	protected Transform healthBarContainerTransform;
	protected Vector3 healthBarContainerTransformPositionOffset;

	// Use this for initialization
	protected void Start () {
		healthBarContainerTransform = transform.parent;
		healthBarContainerTransformPositionOffset = new Vector3(0f, 0.6f);
	}

	// Update is called once per frame
	protected void Update () {
		//healthBarContainerTransform.position = Camera.main.WorldToScreenPoint (new Vector2 (targetTransform.position.x, targetTransform.position.y + 0.6f));
		//Vector3 forwardPosition = Camera.main.transform.TransformPoint(new Vector3(0, 0.6f));
		//resourceBarContainerTransform.position = Camera.main.WorldToScreenPoint(targetTransform.position + forwardPosition - Camera.main.transform.position);
		healthBarContainerTransform.position = targetEntity.transform.position + healthBarContainerTransformPositionOffset;
		transform.localScale = new Vector3(targetEntity.health / targetEntity.maxHealth, 1f, 1f);
	}
}
