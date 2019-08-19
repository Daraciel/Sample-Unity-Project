using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHit : MonoBehaviour
{
    public float LifeTime = 1f;
    public float ElevationDistance = 5f;
    public string SortingLayer = "TEXT";
    public TextMesh Text;
    public float VanishingStartTime;
    public Color TextColor;
    public float verticalMovementStep = 0.1f;

    private bool isVanishing;
    private float currentDistance;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = SortingLayer;
        Text = GetComponent<TextMesh>();
        movement = new Vector3(0, verticalMovementStep, 0);
        currentDistance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDistance < ElevationDistance)
        {
            transform.localPosition += movement;
            currentDistance += verticalMovementStep;
        }
        else
        {
            if(!isVanishing)
            {
                isVanishing = true;
                Destroy(gameObject, LifeTime);
                StartCoroutine(FadeOut());
            }
        }
    }

    IEnumerator FadeOut()
    {
        Color currentColor = Text.color;
        float decresion = 1 / (LifeTime) * Time.deltaTime;
        for (float alpha = 1f; alpha > 0; alpha -= decresion)
        {
            currentColor.a = alpha;
            Text.color = currentColor;
            yield return new WaitForEndOfFrame();
        }
    }
}
