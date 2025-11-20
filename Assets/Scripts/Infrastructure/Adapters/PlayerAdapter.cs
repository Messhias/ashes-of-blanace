using Application;
using Domain.Combat;
using Infrastructure.ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Adapters
{
    public class PlayerAdapter : MonoBehaviour
    {
        [Header("Stats Data (SO)")] [SerializeField]
        private CombatStatsSo initialStats;

        private ICombatant _entity;
        private IBasicAttackService _basicAttack;
        private DodgeService _dodge;

        private Rigidbody _rigidbody;
        private float _movementSpeed = 5f;

        #region engine methods
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            if (initialStats) _entity = new CombatantEntity(initialStats.ToDomainStats());
            _basicAttack = new BasicAttackService();
            _dodge = new DodgeService();
        }

        private void Update()
        {
            HandleMovementInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            HandleCombatInput(Time.deltaTime);
            HandleMpRegeneration(Time.deltaTime);
        }
        
        #endregion

        public void SetRigidBody(Rigidbody rb)
        {
            _rigidbody = rb;
        }

        public void HandleMovementInput(float horizontal, float vert)
        {
            var direction = new Vector3(horizontal, 0, vert).normalized;

            if (direction.magnitude >= 0.1f)
            {
                _rigidbody.linearVelocity = direction * _movementSpeed;

                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                    Time.deltaTime * 10f);
            }
            else
            {
                _rigidbody.linearVelocity = Vector3.zero;
            }
        }

        private void HandleCombatInput(float currentTime)
        {
            if (Input.GetKey("Attack"))
            {
                // TODO: the controller calls the use case.
                // The controller doesn't know the cost or the cooldown.
                // the infra just need to know to who's the target (which implements ICombatant).
                // bool success = _basicAttack.Execute(_entity, targetEntity, currentTime);
                // if (success) {  } // trigger attack animation
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                var success = _dodge.Execute(_entity, currentTime);
                if (success)
                {
                    PerformDodgeMovement();
                }
            }
        }

        private void PerformDodgeMovement()
        {
            Debug.Log("Dodge Executed: Trigger I-frames and Boost.");
        }

        private void HandleMpRegeneration(float deltaTime)
        {
            var regenAmount = _entity.MpRegenPerSecond * deltaTime;
            _entity.RestoreMp(regenAmount);
        }
    }
}