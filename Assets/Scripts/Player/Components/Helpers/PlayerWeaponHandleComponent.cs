using UnityEngine;
using Weapons;

namespace Player
{
    public class PlayerWeaponHandleComponent : BaseComponent, IADSProvider
    {
        [SerializeField] private Transform referenceTransform;
        [SerializeField] private float aimingDistance;

        [SerializeField] private Vector3 adsOffset;
        [SerializeField] private float adsSpeed;

        private Vector3 defaultLocal;

        private bool aiming = false;

        public float ADSMultiplier { get; private set; }
        private Vector3 AimingPoint => referenceTransform.position + referenceTransform.forward * aimingDistance;


        void Start()
        {
            defaultLocal = transform.localPosition;
        }


        void LateUpdate()
        {
            UpdateDirection();

            if (aiming)
                ADSMultiplier = Mathf.Clamp(ADSMultiplier + adsSpeed * Time.deltaTime, 0, 1);
            else
                ADSMultiplier = Mathf.Clamp(ADSMultiplier - adsSpeed * Time.deltaTime, 0, 1);

            transform.localPosition = Vector3.Lerp(defaultLocal, adsOffset, ADSMultiplier);
        }


        public void SetAiming()
        {
            aiming = true;
        }

        public void ReleaseAiming()
        {
            aiming = false;
        }



        private void UpdateDirection()
        {
            var targetDirection = (AimingPoint - transform.position).normalized;

            transform.forward = targetDirection;

            var angles = transform.localEulerAngles;
            angles.z = 0;
            transform.localEulerAngles = angles;
        }
    }
}