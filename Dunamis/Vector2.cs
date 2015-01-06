﻿namespace Dunamis
{
    public struct Vector2
    {
        public float X;
        public float Y;

        #region Methods
        public bool Equals(Vector2 other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector2 && Equals((Vector2)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (X.GetHashCode()*397) ^ Y.GetHashCode();
            }
        }
        #endregion

        #region Operators
        // Math
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
        }
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
        }
        public static Vector2 operator *(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X * right.X, left.Y * right.Y);
        }
        public static Vector2 operator /(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X / right.X, left.Y / right.Y);
        }

        // Equality
        public static bool operator ==(Vector2 left, Vector2 right) // TODO: add equality operators to all dunamis value types
        {
            if (left.X == right.X && left.Y == right.Y)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return !(left == right);
        }

        // Conversion
        public static explicit operator Vector2(Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
        public static explicit operator Vector2(Vector4 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
        public static implicit operator OpenTK.Vector2(Vector2 vector)
        {
            return new OpenTK.Vector2(vector.X, vector.Y);
        }
        public static implicit operator Vector2(OpenTK.Vector2 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
        #endregion

        #region Constructors
        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
