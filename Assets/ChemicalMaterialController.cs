using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalMaterialController : MonoBehaviour
{
    [SerializeField] private Color hotColor;
    [SerializeField] private Color neutralColor;
    [SerializeField] private Color coldColor;
    [SerializeField] private float hotTemperature = 90f;
    [SerializeField] private float neutralTemperature = 26f;
    [SerializeField] private float coldTemperature = -5f;
    public float temperature = 26f;
    private Material material;
    private Color color;
    // Start is called before the first frame update
    void SetColorWithRegardsToTemperature()
    {
        if (temperature <= neutralTemperature)
        {
            material.color = Color.Lerp(coldColor, neutralColor, temperature / (neutralTemperature + coldTemperature));
        }
        else
        {
            material.color = Color.Lerp(hotColor, neutralColor, 1 - (temperature - neutralTemperature) / (temperature + hotTemperature + neutralTemperature));
        }
    }
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        color = material.color;
    }

    // Update is called once per frame
    void Update()
    {
        SetColorWithRegardsToTemperature();
    }
}
