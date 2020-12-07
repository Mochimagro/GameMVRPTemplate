using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Holo5GunGame.Behavior
{

    public class BulletBehavior : MonoBehaviour
    {
        [Header("Component")]
        [SerializeField] private Rigidbody _rigidbody = null;
        [SerializeField] private Collider _collider = null;

        [Header("Particles")]
        [SerializeField] private ParticleSystem _bulletParticle = null;
        [SerializeField] private ParticleSystem _explosionParticle = null;
        [SerializeField] private ParticleSystem _flashParticle = null;

        [Header("AudioSource")]
        [SerializeField] private AudioSource _explosionAudio = null;

        public int Power {  get; set; }


        public Rigidbody Rigidbody
        {
            get { return _rigidbody; }
        }

        public Collider Collider
        {
            get { return _collider; }
        }

        /// <summary>
        /// キャラクターに被弾したときのメソッド
        /// </summary>
        public void HitBullet()
        {

            _collider.enabled = false;

            _bulletParticle.Stop();
            _flashParticle.Stop();
            _explosionParticle.Play();

            _explosionAudio.Play();

            _explosionParticle.OnDisableAsObservable().Subscribe(_ =>
            {
                Destroy(this.gameObject);
            });
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player")) return;

            HitBullet();
        }
    }

}