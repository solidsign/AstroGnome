using UnityEngine;

public class BuffTotem : MonoBehaviour
{
    private ComboHandler player;

    public ComboHandler PlayerComboHandler { set => player = value; }
    private void Start()
    {
        player.IncreaseMinCombo();
    }

    private void OnDisable()
    {
        player.DecreaseMinCombo();
    }
}
