using System.Collections;
using Infrastructure.Adapters;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Tests.Infrastructure
{
    public class MovementTests
    {
        private PlayerAdapter _adapter;
        private Rigidbody _rb;
        private GameObject _player;
        private const float MovementSpeed = 5f;

        [UnitySetUp] 
        public IEnumerator Setup()
        {
            _player = new GameObject("TestPlayer");
            _rb = _player.AddComponent<Rigidbody>();
            _rb.isKinematic = false; 
            _adapter = _player.AddComponent<PlayerAdapter>();
            _adapter.SetRigidBody(_rb);
            yield return null; 
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_player);
        }

        [UnityTest]
        public IEnumerator HandleMovementInput_MovesDiagonally_WhenBothInputsAreActive()
        {
            var horizontal = 1f;
            var vertical = 1f;
            
            var expectedMagnitude = MovementSpeed;
            
            // ACT
            _adapter.HandleMovementInput(horizontal, vertical);
            
            yield return new WaitForFixedUpdate(); 

            
            Assert.AreEqual(expectedMagnitude, _rb.linearVelocity.magnitude, 0.01f,
                "Velocity magnitude is incorrect." +
                $"expected: {expectedMagnitude}, but was : {_rb.linearVelocity.magnitude}");
            
            Assert.AreEqual(0, _rb.linearVelocity.y, "Player should not move on the Y-axis (no jump).");
        }
    }
}