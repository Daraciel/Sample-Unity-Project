using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHitGenerator : MonoBehaviour
{
    public TextHit factoryTextHit;
    public Range defaultOffsetX;
    public Range defaultOffsetY;
    public float defaultLifeTime;

    private void Start()
    {
        defaultOffsetX = new Range();
        defaultOffsetY = new Range();
        defaultLifeTime = 3f;
    }

    public void CreateTextHit(TextHit th, string text, Transform parent, float size, Color color, Range offsetX, Range offsetY, float lifeTime)
    {
        Vector3 offset;
        float xOffset, yOffset;
        TextHit resultText;

        xOffset = UnityEngine.Random.Range(offsetX.MinValue, offsetX.MaxValue);
        yOffset = UnityEngine.Random.Range(offsetY.MinValue, offsetY.MaxValue);
        offset = new Vector2(xOffset, yOffset);

        resultText = Instantiate(th, parent.position + offset, Quaternion.identity, parent);
        resultText.LifeTime = lifeTime;
        resultText.Text.color = color;
        resultText.Text.characterSize = size;
        resultText.Text.text = text;
    }

    public void CreateTextHit(TextHit th, int amountText, Transform parent, float size, Color color, Range offsetX, Range offsetY, float lifeTime)
    {
        CreateTextHit(th, amountText.ToString(), parent, size, color, offsetX, offsetY, lifeTime);
    }

    public void CreateTextHit(int amountText, Transform parent, float size, Color color, Range offsetX, Range offsetY, float lifeTime)
    {
        CreateTextHit(factoryTextHit, amountText.ToString(), parent, size, color, offsetX, offsetY, lifeTime);
    }
}
