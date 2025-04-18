using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VelocityFillBar : MonoBehaviour
{
    public static VelocityFillBar Instance;
    [SerializeField]
    Image FillBar;
    void Start()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (DeckController.Instance == null)
            return;
    }
    public void SetFillAmount(float val)
    {
        FillBar.fillAmount = val;
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
