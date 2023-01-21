using System;
using System.Collections;
using UnityEngine;
using Utils.FactoryTool;

namespace Level.Views
{
    public class PlayerView : PoolableMonoBehaviour
    {
        private Rigidbody _rigidbody;
        
        private int _xDirection;

        private bool _isDead;
        private bool _isInitialized;

        private float _playerSpeed;

        public event Action onDeath;

        private Coroutine _deathCoroutine;
        

        public override void Dispose()
        {
            _xDirection = 0;
            _playerSpeed = 0;
            
            if (_rigidbody != null)
                Destroy(_rigidbody);
            
            if (_deathCoroutine != null)
                StopCoroutine(_deathCoroutine);
            
            _isDead = false;
            _isInitialized = false;
        }

        public void SetPlayerSpeed(float speed)
        {
            _playerSpeed = speed;
        }

        public void SetDirection(Vector3 axis)
        {
            if (_isDead) return;
            
            if (axis.x < 0.0f && _xDirection >= 0)
            {
                _xDirection = -1;
                _isInitialized = true;
            }

            if (axis.x > 0.0f && _xDirection <= 0)
            {
                _xDirection = 1;
                _isInitialized = true;
            }
        }

        private void Update()
        {
            if (!_isInitialized) return;
            
            var moveDirection = _xDirection > 0 ? 
                new Vector3(_xDirection, 0.0f, 0.0f) : 
                new Vector3(0.0f, 0.0f, -_xDirection);
            
            transform.position += moveDirection * (_playerSpeed * Time.deltaTime);
            
            if (_isDead) return;

            _isDead = CheckIfDeath();
            if (_isDead) OnDeath();
        }

        private void OnDeath()
        {
            _rigidbody = gameObject.AddComponent<Rigidbody>();
            _deathCoroutine = StartCoroutine(PlayDeath());
        }

        private IEnumerator PlayDeath()
        {
            yield return new WaitForSeconds(1.0f);
            onDeath?.Invoke();
        }

        private bool CheckIfDeath()
        {
            var ray = new Ray(transform.position, Vector3.down);
            return !Physics.Raycast(ray, 1.0f);
        }
    }
}