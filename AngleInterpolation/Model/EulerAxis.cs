﻿namespace AngleInterpolation.Model
{
    /// <summary>
    /// http://ogre3d.org/tikiwiki/Euler+Angle+Class
    /// http://run.usc.edu/cs520-s14/quaternions/quaternions-cs520.pdf
    /// </summary>
    public class EulerAxis : InterpolationAxis<Vector3>
    {
        #region Private Members

        #endregion Private Members

        #region Constructors

        public EulerAxis(Vector3 startPosition, Vector3 startRotation, Vector3 endPosition, Vector3 endRotation)
            : base(startPosition, startRotation, startRotation, endPosition, endRotation)
        {
        }

        #endregion Constructors

        protected override Vector3 UpdateRotation(Vector3 start, Vector3 destination, double t, int animationTime)
        {
            if (t >= animationTime) return destination;

            return (destination - start) * (t / animationTime) + start;
        }

        protected override Vector3 GetRotation(Vector3 rotation)
        {
            return rotation;
        }

        public override void UpdatePosition(double t, int animationTime)
        {
            base.UpdatePosition(t, animationTime);
            Rotation = UpdateRotation(StartRotation, EndRotation, t, animationTime);
        }
    }
}