using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private TextMesh textMesh;
    private Color textColor;
    private Transform playerTransform;

    private float dissapearTimer = 0.5f;
    private float fadeOutSpeed = 5f;
    private float moveYSpeed = 1f;

	public void SetUp(int amount, Color textC)
    {
        textMesh = GetComponent<TextMesh>();
        playerTransform = Camera.main.transform;
        textColor = textC;
        textMesh.text = amount.ToString();
        textMesh.color = textColor;
    }

	private void LateUpdate()
	{
        if (textMesh != null)
        {
            transform.LookAt(2 * transform.position - playerTransform.position);

            transform.position += new Vector3(0f, moveYSpeed * Time.deltaTime, 0f);

            dissapearTimer -= Time.deltaTime;
            if (dissapearTimer <= 0f)
            {
                textColor.a -= fadeOutSpeed * Time.deltaTime;
                textMesh.color = textColor;
                if (textColor.a <= 0f)
                {
                    Destroy(gameObject);
                }
            }
        }
	}
}
