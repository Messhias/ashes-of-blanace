using System.Collections;
using Infrastructure.Controllers;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Tests.Infrastructure
{
    public class MovementTests
    {
        private PlayerController _controller;
        private Rigidbody _rb;
        private GameObject _player;
        private const float MovementSpeed = 5f;

        [UnitySetUp] 
        public IEnumerator Setup()
        {
            _player = new GameObject("TestPlayer");
            _rb = _player.AddComponent<Rigidbody>();
            _rb.isKinematic = false; 
            _controller = _player.AddComponent<PlayerController>();
            _controller.SetRigidBody(_rb);
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
            _controller.HandleMovementInput(horizontal, vertical);
            
            yield return new WaitForFixedUpdate(); 

            
            Assert.AreEqual(expectedMagnitude, _rb.linearVelocity.magnitude, 0.01f,
                "Velocity magnitude is incorrect." +
                $"expected: {expectedMagnitude}, but was : {_rb.linearVelocity.magnitude}");
            
            Assert.AreEqual(0, _rb.linearVelocity.y, "Player should not move on the Y-axis (no jump).");
        }
    }
}