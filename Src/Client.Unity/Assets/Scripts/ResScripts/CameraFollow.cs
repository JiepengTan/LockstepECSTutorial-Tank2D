﻿using UnityEngine;
using System.Collections;
using Lockstep.Game;

namespace Lockstep.Game {
    public class CameraFollow : MonoBehaviour {
        public Transform _target;

        public Transform target {
            get => _target;
            set {
                _target = value;
                if (_target != null)
                    offset = transform.position - _target.position;
            }
        } // The position that that camera will be following.

        public float smoothing = 5f; // The speed with which the camera will be following.


        Vector3 offset; // The initial offset from the target.


        void Update(){
            if (_target == null) {
               target = World.MyPlayer as Transform;
            }

            if (_target == null) return;
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, 0.1f);
        }
    }
}