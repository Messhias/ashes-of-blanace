using Application;
using Domain.Combat;
using Infrastructure.ScriptableObjects;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Infrastructure.Adapters
{
    public class PlayerAdapter : MonoBehaviour
    {
        #region Unity Editor
        
        [Header("Stats Data (SO)")] [SerializeField]
        private CombatStatsSo initialStats;

        [Header("Attack hit box")] [SerializeField]
        private AttackHitBox attackHitBox;
        
        [Header("Visual/SFX")] [SerializeField]
        private AudioSource audioSource;

        [SerializeField] private AudioClip basicAttackSfx;
        [SerializeField] private AudioClip strongAttackSfx;

        #endregion
        
        private ICombatant _entity;
        private IAbstractAttackService _basicAttack;
        private IAbstractAttackService _strongAttack;
        private DodgeService _dodge;

        private Rigidbody _rigidbody;
        private float _movementSpeed = 5f;
        private InputSystem_Actions _inputActions;
        private bool _isAttacking;
        
        #region engine methods
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            if (initialStats) _entity = new CombatantEntity(initialStats.ToDomainStats());
            _basicAttack = new BasicAttackService();
            _strongAttack = new StrongAttackService();
            _dodge = new DodgeService();

            _basicAttack.OnAttackExecuted += HandleBasicAttackExecuted;
            _strongAttack.OnAttackExecuted += HandleStrongAttackExecuted;

            if (attackHitBox != null)
            {
                attackHitBox.SetBasicAttack(_basicAttack);
                attackHitBox.SetEntity(_entity);
            }
            
            _inputActions = new InputSystem_Actions();
        }

        private void HandleStrongAttackExecuted(ICombatant arg1, ICombatant arg2)
        {
            PlayAttackSfx(strongAttackSfx);
        }

        private void HandleBasicAttackExecuted(ICombatant arg1, ICombatant arg2)
        {
            PlayAttackSfx(basicAttackSfx);
        }

        private void OnEnable()
        {
            _inputActions.Enable();
        }

        private void OnDisable()
        {
            _inputActions.Disable();
        }

        private void OnDestroy()
        {
            if (_basicAttack is AbstractAttackService basic)
            {
                basic.OnAttackExecuted -= HandleBasicAttackExecuted;
            }

            if (_strongAttack is AbstractAttackService strong)
            {
                strong.OnAttackExecuted -= HandleStrongAttackExecuted;
            }
            _inputActions.Dispose();
        }

        private void Update()
        {
            HandleMovementInput(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            HandleCombatInput(Time.time);
            HandleMpRegeneration(Time.deltaTime);

            if (_entity is CombatantEntity entity)
            {
                entity.UpdateInvincibility(Time.time);
            }
        }
        
        #endregion
        
        public ICombatant GetCombatantEntity() => _entity;

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
            if (_inputActions.Player.Attack.WasPressedThisFrame() && !_isAttacking)
            {
                _isAttacking = true;
                TriggerAttack(_basicAttack, basicAttackSfx);
            }

            if (_inputActions.Player.Attack.WasReleasedThisFrame())
            {
                _isAttacking = false;
            }

            if (_inputActions.Player.Jump.WasPressedThisFrame() && !_isAttacking)
            {
                var success = TryExecuteStrongAttack(currentTime);
                if (success)
                {
                    TriggerAttack(_strongAttack, strongAttackSfx);
                }
            }
            
            if (_inputActions.Player.Sprint.WasPressedThisFrame() && !_isAttacking)
            {
                var success = _dodge.Execute(_entity, currentTime);
                if (success)
                {
                    PerformDodgeMovement();
                }
            }
        }

        private void TriggerAttack(IAbstractAttackService attackService, AudioClip attackSfx)
        {
            if (attackHitBox != null)
            {
                attackHitBox.SetBasicAttack(attackService);
            }

            PlayAttackSfx(attackSfx);
        }

        private void PlayAttackSfx(AudioClip attackSfx)
        {
            if (audioSource != null && attackSfx)
            {
                audioSource.PlayOneShot(attackSfx);
            }
        }

        private bool TryExecuteStrongAttack(float currentTime)
        {
            if (_entity == null) return false;

            var nearbyEnemy = FindNearestEnemy();
            if (nearbyEnemy == null) return false;

            return _strongAttack.Execute(_entity, nearbyEnemy, currentTime);
        }

        private ICombatant FindNearestEnemy()
        {
            // TODO: update this to get the real nearest enemy within weapon radius.
            var enemies = FindObjectsByType<EnemyAdapter>(FindObjectsSortMode.None);
            if (enemies.Length == 0) return null;

            var nearest = enemies[0];
            var nearestDistance = Vector3.Distance(transform.position, nearest.transform.position);

            foreach (var enemy in enemies)
            {
                var distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearest = enemy;
                    nearestDistance = distance;
                }
            }

            return nearest.GetCombatantEntity();
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