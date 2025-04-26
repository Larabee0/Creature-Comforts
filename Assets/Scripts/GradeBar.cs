using UnityEngine;
using UnityEngine.UI;

public class GradeBar : MonoBehaviour
{
    [SerializeField] private Image bar;

    private void Awake()
    {
        bar.type = Image.Type.Filled;
        bar.fillMethod = Image.FillMethod.Horizontal;
        bar.fillOrigin = 0;
        bar.fillAmount = 0;
    }

    public void SetFill(int fillAmount)
    {
        fillAmount = Mathf.Clamp(fillAmount, 0, 10);

        bar.fillAmount = (float)fillAmount / 10;
    }
}
