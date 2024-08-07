using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deep
{
    //TODO gotta rename this... idk
    public class PlayerTouch : DeepBehavior
    {
        [SerializeField] private float _aoeRadius;
        [SerializeField] private float _force;

        public PlayerTouch(float aoeRadius, float force)
        {
            _aoeRadius = aoeRadius;
            _force = force;
        }

        public override void Init()
        {
            parent.events.OnEntityCollisionEnter += OnCollision;
        }
        public override void Teardown()
        {
            parent.events.OnEntityCollisionEnter -= OnCollision;
        }

        private void OnCollision(DeepEntity e)
        {
            if (e.team == D_Team.Enemy)
            {
                DeepUtility.AreaImpulse(parent.transform.position, _aoeRadius, _force, D_Team.Enemy);
                DeepUtility.AreaBehavior(
                    parent.transform.position,
                    _aoeRadius,
                    new DecayingAttributeMod(D_Attribute.MoveSpeed, new ModValues(0f, -.9f, 0f), 3f),
                    owner,
                    D_Team.Enemy);
            }
        }
    }
}
