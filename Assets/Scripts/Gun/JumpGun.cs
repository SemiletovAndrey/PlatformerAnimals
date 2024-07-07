using UnityEngine;

public class JumpGun : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyPlayer;
    [SerializeField] private float speed;
    [SerializeField] private Transform spawn;
    [SerializeField] private Gun pistol;
    [SerializeField] private ChargeIcon chargeIcon;
    [SerializeField] private PlayerArmory playerArmory;

    [SerializeField] private float maxCharge = 3;
    private float _currentCharge;
    private bool _isCharged;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                rigidbodyPlayer.AddForce(-spawn.forward * speed, ForceMode.VelocityChange);
                pistol.Shot();
                _isCharged = false;
                _currentCharge = 0f;
                chargeIcon.StartCharge();

            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            chargeIcon.SetChargeValue(_currentCharge, maxCharge);
            if (_currentCharge >= maxCharge)
            {
                _isCharged = true;
                chargeIcon.StopCharge();
            }
        }

    }
}
