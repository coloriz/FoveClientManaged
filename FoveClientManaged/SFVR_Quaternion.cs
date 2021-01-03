using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fove.Managed
{
    public struct SFVR_Quaternion
    {
        /// <summary>
        ///   <para>X component of the Quaternion. Don't modify this directly unless you know quaternions inside out.</para>
        /// </summary>
        public float x;

        /// <summary>
        ///   <para>Y component of the Quaternion. Don't modify this directly unless you know quaternions inside out.</para>
        /// </summary>
        public float y;

        /// <summary>
        ///   <para>Z component of the Quaternion. Don't modify this directly unless you know quaternions inside out.</para>
        /// </summary>
        public float z;

        /// <summary>
        ///   <para>W component of the Quaternion. Don't modify this directly unless you know quaternions inside out.</para>
        /// </summary>
        public float w;

        private static readonly SFVR_Quaternion identityQuaternion = new SFVR_Quaternion(0f, 0f, 0f, 1f);

        public const float kEpsilon = 1E-06f;

        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.x;
                    case 1:
                        return this.y;
                    case 2:
                        return this.z;
                    case 3:
                        return this.w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        this.x = value;
                        break;
                    case 1:
                        this.y = value;
                        break;
                    case 2:
                        this.z = value;
                        break;
                    case 3:
                        this.w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion index!");
                }
            }
        }

        /// <summary>
        ///   <para>The identity rotation (Read Only).</para>
        /// </summary>
        public static SFVR_Quaternion Identity
        {
            get
            {
                return SFVR_Quaternion.identityQuaternion;
            }
        }

        /// <summary>
        ///   <para>Returns the euler angle representation of the rotation.</para>
        /// </summary>
        public SFVR_Vec3 EulerAngles
        {
            get
            {
                return SFVR_Quaternion.ToEulerRad(this) * MathExtension.rad2deg;
            }
            set
            {
                this = SFVR_Quaternion.FromEulerRad(value * MathExtension.deg2rad);
            }
        }

        /// <summary>
        /// Gets the length (magnitude) of the quaternion.
        /// </summary>
        /// <seealso cref="LengthSquared"/>
        public float Length
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z * z + w * w);
            }
        }

        /// <summary>
        /// Gets the square of the quaternion length (magnitude).
        /// </summary>
        public float LengthSquared
        {
            get
            {
                return x * x + y * y + z * z + w * w;
            }
        }

        /// <summary>
        ///   <para>Constructs new Quaternion with given x,y,z,w components.</para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public SFVR_Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        ///   <para>Set x, y, z and w components of an existing Quaternion.</para>
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newZ"></param>
        /// <param name="newW"></param>
        public void Set(float newX, float newY, float newZ, float newW)
        {
            this.x = newX;
            this.y = newY;
            this.z = newZ;
            this.w = newW;
        }

        /// <summary>
        /// Scales the MyQuaternion to unit length.
        /// </summary>
        public void Normalize()
        {
            float scale = 1.0f / this.Length;
            x *= scale;
            y *= scale;
            z *= scale;
            w *= scale;
        }

        /// <summary>
        /// Scale the given quaternion to unit length
        /// </summary>
        /// <param name="q">The quaternion to normalize</param>
        /// <returns>The normalized quaternion</returns>
        public static SFVR_Quaternion Normalize(SFVR_Quaternion q)
        {
            SFVR_Quaternion result;
            Normalize(ref q, out result);
            return result;
        }

        /// <summary>
        /// Scale the given quaternion to unit length
        /// </summary>
        /// <param name="q">The quaternion to normalize</param>
        /// <param name="result">The normalized quaternion</param>
        public static void Normalize(ref SFVR_Quaternion q, out SFVR_Quaternion result)
        {
            float scale = 1.0f / q.Length;
            result = new SFVR_Quaternion(q.x * scale, q.y * scale, q.z * scale, q.w * scale);
        }

        public static SFVR_Quaternion operator *(SFVR_Quaternion lhs, SFVR_Quaternion rhs)
        {
            return new SFVR_Quaternion(lhs.w * rhs.x + lhs.x * rhs.w + lhs.y * rhs.z - lhs.z * rhs.y, lhs.w * rhs.y + lhs.y * rhs.w + lhs.z * rhs.x - lhs.x * rhs.z, lhs.w * rhs.z + lhs.z * rhs.w + lhs.x * rhs.y - lhs.y * rhs.x, lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z);
        }

        public static SFVR_Vec3 operator *(SFVR_Quaternion rotation, SFVR_Vec3 point)
        {
            float num = rotation.x * 2f;
            float num2 = rotation.y * 2f;
            float num3 = rotation.z * 2f;
            float num4 = rotation.x * num;
            float num5 = rotation.y * num2;
            float num6 = rotation.z * num3;
            float num7 = rotation.x * num2;
            float num8 = rotation.x * num3;
            float num9 = rotation.y * num3;
            float num10 = rotation.w * num;
            float num11 = rotation.w * num2;
            float num12 = rotation.w * num3;
            SFVR_Vec3 result = default(SFVR_Vec3);
            result.x = (1f - (num5 + num6)) * point.x + (num7 - num12) * point.y + (num8 + num11) * point.z;
            result.y = (num7 + num12) * point.x + (1f - (num4 + num6)) * point.y + (num9 - num10) * point.z;
            result.z = (num8 - num11) * point.x + (num9 + num10) * point.y + (1f - (num4 + num5)) * point.z;
            return result;
        }

        public static bool operator ==(SFVR_Quaternion lhs, SFVR_Quaternion rhs)
        {
            return SFVR_Quaternion.Dot(lhs, rhs) > 0.999999f;
        }

        public static bool operator !=(SFVR_Quaternion lhs, SFVR_Quaternion rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        ///   <para>The dot product between two rotations.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static float Dot(SFVR_Quaternion a, SFVR_Quaternion b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;
        }

        /// <summary>
        ///   <para>Creates a rotation which rotates /angle/ degrees around /axis/.</para>
        /// </summary>
        /// <param name="angle"></param>
        /// <param name="axis"></param>
        public static SFVR_Quaternion AngleAxis(float angle, SFVR_Vec3 axis)
        {
            return SFVR_Quaternion.AngleAxis(angle, ref axis);
        }

        private static SFVR_Quaternion AngleAxis(float degress, ref SFVR_Vec3 axis)
        {
            if (axis.SqrMagnitude == 0.0f)
                return Identity;

            SFVR_Quaternion result = Identity;
            var radians = degress * MathExtension.deg2rad;
            radians *= 0.5f;
            axis.Normalize();
            axis = axis * (float)Math.Sin(radians);
            result.x = axis.x;
            result.y = axis.y;
            result.z = axis.z;
            result.w = (float)Math.Cos(radians);

            return Normalize(result);
        }

        public void ToAngleAxis(out float angle, out SFVR_Vec3 axis)
        {
            SFVR_Quaternion.ToAxisAngleRad(this, out axis, out angle);
            angle *= MathExtension.rad2deg;
        }

        /// <summary>
        ///   <para>Returns the Inverse of /rotation/.</para>
        /// </summary>
        /// <param name="rotation"></param>
        public static SFVR_Quaternion Inverse(SFVR_Quaternion rotation)
        {
            float lengthSq = rotation.LengthSquared;
            if (lengthSq != 0.0)
            {
                float i = 1.0f / lengthSq;
                return new SFVR_Quaternion(rotation.x * -i, rotation.y * -i, rotation.z * -i, rotation.w * i);
            }
            return rotation;
        }

        /// <summary>
        ///   <para>Returns the angle in degrees between two rotations a and b.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static float Angle(SFVR_Quaternion a, SFVR_Quaternion b)
        {
            float f = SFVR_Quaternion.Dot(a, b);
            return (float)Math.Acos(Math.Min(Math.Abs(f), 1f)) * 2f * MathExtension.rad2deg;
        }

        /// <summary>
        ///   <para>Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).</para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static SFVR_Quaternion Euler(float x, float y, float z)
        {
            return SFVR_Quaternion.FromEulerRad(new SFVR_Vec3(x, y, z) * MathExtension.deg2rad);
        }

        /// <summary>
        ///   <para>Returns a rotation that rotates z degrees around the z axis, x degrees around the x axis, and y degrees around the y axis (in that order).</para>
        /// </summary>
        /// <param name="euler"></param>
        public static SFVR_Quaternion Euler(SFVR_Vec3 euler)
        {
            return SFVR_Quaternion.FromEulerRad(euler * MathExtension.deg2rad);
        }

        private static SFVR_Vec3 ToEulerRad(SFVR_Quaternion rotation)
        {
            float sqw = rotation.w * rotation.w;
            float sqx = rotation.x * rotation.x;
            float sqy = rotation.y * rotation.y;
            float sqz = rotation.z * rotation.z;
            float unit = sqx + sqy + sqz + sqw; // if normalised is one, otherwise is correction factor
            float test = rotation.x * rotation.w - rotation.y * rotation.z;
            SFVR_Vec3 v;

            if (test > 0.4995f * unit)
            { // singularity at north pole
                v.y = 2f * (float)Math.Atan2(rotation.y, rotation.x);
                v.x = (float)Math.PI / 2f;
                v.z = 0;
                return NormalizeAngles(v * MathExtension.rad2deg);
            }
            if (test < -0.4995f * unit)
            { // singularity at south pole
                v.y = -2f * (float)Math.Atan2(rotation.y, rotation.x);
                v.x = (float)-Math.PI / 2f;
                v.z = 0;
                return NormalizeAngles(v * MathExtension.rad2deg);
            }
            SFVR_Quaternion q = new SFVR_Quaternion(rotation.w, rotation.z, rotation.x, rotation.y);
            v.y = (float)Math.Atan2(2f * q.x * q.w + 2f * q.y * q.z, 1 - 2f * (q.z * q.z + q.w * q.w));		// Yaw
            v.x = (float)Math.Asin(2f * (q.x * q.z - q.w * q.y));											// Pitch
            v.z = (float)Math.Atan2(2f * q.x * q.y + 2f * q.z * q.w, 1 - 2f * (q.y * q.y + q.z * q.z));		// Roll
            return NormalizeAngles(v);
        }

        private static SFVR_Vec3 NormalizeAngles(SFVR_Vec3 angles)
        {
            angles.x = NormalizeAngle(angles.x);
            angles.y = NormalizeAngle(angles.y);
            angles.z = NormalizeAngle(angles.z);
            return angles;
        }

        private static float NormalizeAngle(float angle)
        {
            while (angle > 2f * (float)Math.PI)
                angle -= 2f * (float)Math.PI;
            while (angle < 0)
                angle += 2f * (float)Math.PI;
            return angle;
        }

        private static SFVR_Quaternion FromEulerRad(SFVR_Vec3 euler)
        {
            var yaw = euler.x;
            var pitch = euler.y;
            var roll = euler.z;
            float rollOver2 = roll * 0.5f;
            float sinRollOver2 = (float)Math.Sin(rollOver2);
            float cosRollOver2 = (float)Math.Cos(rollOver2);
            float pitchOver2 = pitch * 0.5f;
            float sinPitchOver2 = (float)Math.Sin(pitchOver2);
            float cosPitchOver2 = (float)Math.Cos(pitchOver2);
            float yawOver2 = yaw * 0.5f;
            float sinYawOver2 = (float)Math.Sin(yawOver2);
            float cosYawOver2 = (float)Math.Cos(yawOver2);
            SFVR_Quaternion result;
            result.x = cosYawOver2 * cosPitchOver2 * cosRollOver2 + sinYawOver2 * sinPitchOver2 * sinRollOver2;
            result.y = cosYawOver2 * cosPitchOver2 * sinRollOver2 - sinYawOver2 * sinPitchOver2 * cosRollOver2;
            result.z = cosYawOver2 * sinPitchOver2 * cosRollOver2 + sinYawOver2 * cosPitchOver2 * sinRollOver2;
            result.w = sinYawOver2 * cosPitchOver2 * cosRollOver2 - cosYawOver2 * sinPitchOver2 * sinRollOver2;
            return result;

        }
        private static void ToAxisAngleRad(SFVR_Quaternion q, out SFVR_Vec3 axis, out float angle)
        {
            if (Math.Abs(q.w) > 1.0f)
                q.Normalize();
            angle = 2.0f * (float)Math.Acos(q.w); // angle
            float den = (float)Math.Sqrt(1.0 - q.w * q.w);
            if (den > 0.0001f)
            {
                axis = new SFVR_Vec3(q.x / den, q.y / den, q.z / den);
            }
            else
            {
                // This occurs when the angle is zero. 
                // Not a problem: just set an arbitrary normalized axis.
                axis = new SFVR_Vec3(1, 0, 0);
            }
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2 ^ this.w.GetHashCode() >> 1;
        }

        public override bool Equals(object other)
        {
            if (!(other is SFVR_Quaternion))
            {
                return false;
            }
            SFVR_Quaternion quaternion = (SFVR_Quaternion)other;
            return this.x.Equals(quaternion.x) && this.y.Equals(quaternion.y) && this.z.Equals(quaternion.z) && this.w.Equals(quaternion.w);
        }

        /// <summary>
        ///   <para>Returns a nicely formatted string of the Quaternion.</para>
        /// </summary>
        /// <param name="format"></param>
        public override string ToString()
        {
            return String.Format("({0:F1}, {1:F1}, {2:F1}, {3:F1})", this.x, this.y, this.z, this.w);
        }
    }
}
