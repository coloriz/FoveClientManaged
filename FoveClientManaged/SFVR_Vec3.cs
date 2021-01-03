using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fove.Managed
{
    public struct SFVR_Vec3
    {
        public const float kEpsilon = 1E-05f;

        /// <summary>
        ///   <para>X component of the vector.</para>
        /// </summary>
        public float x;

        /// <summary>
        ///   <para>Y component of the vector.</para>
        /// </summary>
        public float y;

        /// <summary>
        ///   <para>Z component of the vector.</para>
        /// </summary>
        public float z;

        private static readonly SFVR_Vec3 zeroVector = new SFVR_Vec3(0f, 0f, 0f);

        private static readonly SFVR_Vec3 oneVector = new SFVR_Vec3(1f, 1f, 1f);

        private static readonly SFVR_Vec3 upVector = new SFVR_Vec3(0f, 1f, 0f);

        private static readonly SFVR_Vec3 downVector = new SFVR_Vec3(0f, -1f, 0f);

        private static readonly SFVR_Vec3 leftVector = new SFVR_Vec3(-1f, 0f, 0f);

        private static readonly SFVR_Vec3 rightVector = new SFVR_Vec3(1f, 0f, 0f);

        private static readonly SFVR_Vec3 forwardVector = new SFVR_Vec3(0f, 0f, 1f);

        private static readonly SFVR_Vec3 backVector = new SFVR_Vec3(0f, 0f, -1f);

        private static readonly SFVR_Vec3 positiveInfinityVector = new SFVR_Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        private static readonly SFVR_Vec3 negativeInfinityVector = new SFVR_Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);

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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
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
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        /// <summary>
        ///   <para>Returns this vector with a magnitude of 1 (Read Only).</para>
        /// </summary>
        public SFVR_Vec3 Normalized
        {
            get
            {
                return SFVR_Vec3.Normalize(this);
            }
        }

        /// <summary>
        ///   <para>Returns the length of this vector (Read Only).</para>
        /// </summary>
        public float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);
            }
        }

        /// <summary>
        ///   <para>Returns the squared length of this vector (Read Only).</para>
        /// </summary>
        public float SqrMagnitude
        {
            get
            {
                return this.x * this.x + this.y * this.y + this.z * this.z;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(0, 0, 0).</para>
        /// </summary>
        public static SFVR_Vec3 Zero
        {
            get
            {
                return SFVR_Vec3.zeroVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(1, 1, 1).</para>
        /// </summary>
        public static SFVR_Vec3 One
        {
            get
            {
                return SFVR_Vec3.oneVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(0, 0, 1).</para>
        /// </summary>
        public static SFVR_Vec3 Forward
        {
            get
            {
                return SFVR_Vec3.forwardVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(0, 0, -1).</para>
        /// </summary>
        public static SFVR_Vec3 Back
        {
            get
            {
                return SFVR_Vec3.backVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(0, 1, 0).</para>
        /// </summary>
        public static SFVR_Vec3 Up
        {
            get
            {
                return SFVR_Vec3.upVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(0, -1, 0).</para>
        /// </summary>
        public static SFVR_Vec3 Down
        {
            get
            {
                return SFVR_Vec3.downVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(-1, 0, 0).</para>
        /// </summary>
        public static SFVR_Vec3 Left
        {
            get
            {
                return SFVR_Vec3.leftVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(1, 0, 0).</para>
        /// </summary>
        public static SFVR_Vec3 Right
        {
            get
            {
                return SFVR_Vec3.rightVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity).</para>
        /// </summary>
        public static SFVR_Vec3 PositiveInfinity
        {
            get
            {
                return SFVR_Vec3.positiveInfinityVector;
            }
        }

        /// <summary>
        ///   <para>Shorthand for writing SFVR_Vec3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity).</para>
        /// </summary>
        public static SFVR_Vec3 NegativeInfinity
        {
            get
            {
                return SFVR_Vec3.negativeInfinityVector;
            }
        }

        /// <summary>
        ///   <para>Creates a new vector with given x, y, z components.</para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public SFVR_Vec3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        ///   <para>Creates a new vector with given x, y components and sets z to zero.</para>
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public SFVR_Vec3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0f;
        }

        /// <summary>
        ///   <para>Set x, y and z components of an existing SFVR_Vec3.</para>
        /// </summary>
        /// <param name="newX"></param>
        /// <param name="newY"></param>
        /// <param name="newZ"></param>
        public void Set(float newX, float newY, float newZ)
        {
            this.x = newX;
            this.y = newY;
            this.z = newZ;
        }

        /// <summary>
        ///   <para>Multiplies two vectors component-wise.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static SFVR_Vec3 Scale(SFVR_Vec3 a, SFVR_Vec3 b)
        {
            return new SFVR_Vec3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        /// <summary>
        ///   <para>Multiplies every component of this vector by the same component of scale.</para>
        /// </summary>
        /// <param name="scale"></param>
        public void Scale(SFVR_Vec3 scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
            this.z *= scale.z;
        }

        /// <summary>
        ///   <para>Cross Product of two vectors.</para>
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        public static SFVR_Vec3 Cross(SFVR_Vec3 lhs, SFVR_Vec3 rhs)
        {
            return new SFVR_Vec3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }

        public override int GetHashCode()
        {
            return this.x.GetHashCode() ^ this.y.GetHashCode() << 2 ^ this.z.GetHashCode() >> 2;
        }

        /// <summary>
        ///   <para>Returns true if the given vector is exactly equal to this vector.</para>
        /// </summary>
        /// <param name="other"></param>
        public override bool Equals(object other)
        {
            if (!(other is SFVR_Vec3))
            {
                return false;
            }
            SFVR_Vec3 vector = (SFVR_Vec3)other;
            return this.x.Equals(vector.x) && this.y.Equals(vector.y) && this.z.Equals(vector.z);
        }

        /// <summary>
        ///   <para>Reflects a vector off the plane defined by a normal.</para>
        /// </summary>
        /// <param name="inDirection"></param>
        /// <param name="inNormal"></param>
        public static SFVR_Vec3 Reflect(SFVR_Vec3 inDirection, SFVR_Vec3 inNormal)
        {
            return -2f * SFVR_Vec3.Dot(inNormal, inDirection) * inNormal + inDirection;
        }

        /// <summary>
        ///   <para>Makes this vector have a magnitude of 1.</para>
        /// </summary>
        /// <param name="value"></param>
        public static SFVR_Vec3 Normalize(SFVR_Vec3 value)
        {
            float num = value.Magnitude;
            if (num > 1E-05f)
            {
                return value / num;
            }
            return SFVR_Vec3.Zero;
        }

        public void Normalize()
        {
            float num = this.Magnitude;
            if (num > 1E-05f)
            {
                this /= num;
            }
            else
            {
                this = SFVR_Vec3.Zero;
            }
        }

        /// <summary>
        ///   <para>Dot Product of two vectors.</para>
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        public static float Dot(SFVR_Vec3 lhs, SFVR_Vec3 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        /// <summary>
        ///   <para>Returns the angle in degrees between from and to.</para>
        /// </summary>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <param name="to">The vector to which the angular difference is measured.</param>
        public static float Angle(SFVR_Vec3 from, SFVR_Vec3 to)
        {
            return (float)Math.Acos(MathExtension.Clamp(SFVR_Vec3.Dot(from.Normalized, to.Normalized), -1f, 1f)) * MathExtension.rad2deg;
        }

        /// <summary>
        ///   <para>Returns the signed angle in degrees between from and to.</para>
        /// </summary>
        /// <param name="from">The vector from which the angular difference is measured.</param>
        /// <param name="to">The vector to which the angular difference is measured.</param>
        /// <param name="axis">A vector around which the other vectors are rotated.</param>
        public static float SignedAngle(SFVR_Vec3 from, SFVR_Vec3 to, SFVR_Vec3 axis)
        {
            SFVR_Vec3 normalized = from.Normalized;
            SFVR_Vec3 normalized2 = to.Normalized;
            float num = (float)Math.Acos(MathExtension.Clamp(SFVR_Vec3.Dot(normalized, normalized2), -1f, 1f)) * MathExtension.rad2deg;
            float num2 = Math.Sign(SFVR_Vec3.Dot(axis, SFVR_Vec3.Cross(normalized, normalized2)));
            return num * num2;
        }

        /// <summary>
        ///   <para>Returns the distance between a and b.</para>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static float Distance(SFVR_Vec3 a, SFVR_Vec3 b)
        {
            SFVR_Vec3 vector = new SFVR_Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
            return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static SFVR_Vec3 operator +(SFVR_Vec3 a, SFVR_Vec3 b)
        {
            return new SFVR_Vec3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static SFVR_Vec3 operator -(SFVR_Vec3 a, SFVR_Vec3 b)
        {
            return new SFVR_Vec3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static SFVR_Vec3 operator -(SFVR_Vec3 a)
        {
            return new SFVR_Vec3(0f - a.x, 0f - a.y, 0f - a.z);
        }

        public static SFVR_Vec3 operator *(SFVR_Vec3 a, float d)
        {
            return new SFVR_Vec3(a.x * d, a.y * d, a.z * d);
        }

        public static SFVR_Vec3 operator *(float d, SFVR_Vec3 a)
        {
            return new SFVR_Vec3(a.x * d, a.y * d, a.z * d);
        }

        public static SFVR_Vec3 operator /(SFVR_Vec3 a, float d)
        {
            return new SFVR_Vec3(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(SFVR_Vec3 lhs, SFVR_Vec3 rhs)
        {
            return (lhs - rhs).SqrMagnitude < 9.99999944E-11f;
        }

        public static bool operator !=(SFVR_Vec3 lhs, SFVR_Vec3 rhs)
        {
            return !(lhs == rhs);
        }

        /// <summary>
        ///   <para>Returns a nicely formatted string for this vector.</para>
        /// </summary>
        /// <param name="format"></param>
        public override string ToString()
        {
            return String.Format("({0:F1}, {1:F1}, {2:F1})", this.x, this.y, this.z);
        }
    }
}
