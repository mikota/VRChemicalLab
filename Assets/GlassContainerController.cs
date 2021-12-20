using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassContainerController : MonoBehaviour
{
    public GameObject GlassLiquid;
    public GameObject HolePoint;
    public float fillIncrement = 0.33f;
    private float fillAmount;
    public float startingFillAmount = 0.284f;
    public GameObject waterDropletPrefab;
    Material liquidMaterial;
    public Color sideColor = new Color(103, 197, 221);
    public Color topColor = new Color(133,159,215);

    // Start is called before the first frame update
    IEnumerator SpawnLiquidParticle()
    {
        while (true)
        {
            float absRotX = Mathf.Abs(transform.rotation.eulerAngles.x);
            float absRotZ = Mathf.Abs(transform.rotation.eulerAngles.z);
            if (fillAmount > .192)
            {
                if ((absRotX > 90 && absRotX < 270) || (absRotZ > 90 && absRotZ < 270))
                {
                    IncrementFillAmount(-fillIncrement);
                    Instantiate(waterDropletPrefab, HolePoint.transform.position, Quaternion.identity);
                }
                else
                {
                    
                }
            } else
            {

            }
            yield return new WaitForSeconds(.33f);
        }
    }
    void Start()
    {

        fillAmount = startingFillAmount;
        liquidMaterial = GlassLiquid.GetComponent<Renderer>().material;
        liquidMaterial.SetColor("_SideColor", sideColor);
        liquidMaterial.SetColor("_TopColor", topColor);
        StartCoroutine(SpawnLiquidParticle());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLiquidShader();
    }
    public Material GetLiquidMaterial()
    {
        return liquidMaterial;
    }
    private float GetLiquidShaderFillAmount()
    {
        return liquidMaterial.GetFloat("Vector1_a30bf3cdb53a4a6b871f0e97d2f6073f");
    }
    private void UpdateLiquidShader()
    {
        liquidMaterial.SetFloat("Vector1_a30bf3cdb53a4a6b871f0e97d2f6073f", fillAmount);
    }
    public void IncrementFillAmount(float fillIncrement)
    {
        fillAmount += fillIncrement;
    }
}
