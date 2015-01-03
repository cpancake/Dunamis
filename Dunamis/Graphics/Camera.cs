﻿using System;

namespace Dunamis.Graphics
{
    public class Camera
    {
        Matrix4 view;      
        Matrix4 projection;
        bool viewCalculated;
        bool projectionCalculated;

        Vector3 position;
        Vector3 direction;
        float pitch;
        float yaw;

        Angle fieldOfView;
        Vector2 aspect;

        public Matrix4 View
        {
            get
            {
                if (!viewCalculated)
                {
                    view = OpenTK.Matrix4.LookAt(position, position + direction, new OpenTK.Vector3(0, 1, 0));
                    //view = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(0, 0, 3f), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 1, 0));
                    viewCalculated = true;
                }
                return view;
            }
        }
        public Matrix4 Projection
        {
            get
            {
                if (!projectionCalculated)
                {
                    projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(fieldOfView.Radians, aspect.X / aspect.Y, 0.5f, 1024); // TODO: investigate znear and zfar more
                    projectionCalculated = true;
                }
                return projection;
            }
        }
        public Vector3 Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position != value)
                {
                    position = value;
                    viewCalculated = false;
                }
            }
        }
        public float Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                if (pitch != value)
                {
                    pitch = value;
                    viewCalculated = false;
                    direction.X = (float)Math.Cos(pitch) * (float)Math.Cos(yaw);
                    direction.Y = (float)Math.Sin(pitch);
                    direction.Z = (float)Math.Cos(pitch) * (float)Math.Sin(yaw);
                }
            }
        }
        public float Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                if (yaw != value)
                {
                    yaw = value;
                    viewCalculated = false;
                    direction.X = (float)Math.Cos(pitch) * (float)Math.Cos(yaw);
                    direction.Z = (float)Math.Cos(pitch) * (float)Math.Sin(yaw);
                }
            }
        }
        public float FieldOfView
        {
            get
            {
                return fieldOfView.Degrees;
            }
            set
            {
                if (fieldOfView.Degrees != value)
                {
                    fieldOfView.Degrees = value;
                    projectionCalculated = false;
                }
            }
        }
        public Vector2 Aspect
        {
            get
            {
                return aspect;
            }
            set
            {
                if (aspect != value)
                {
                    aspect = value;
                    projectionCalculated = false;
                }
            }
        }

        public Camera()
        {
            position = new Vector3(0.0f, 0.0f, 0.0f);
            pitch = 0f;
            yaw = 0f;
            fieldOfView = Angle.CreateDegrees(90).Radians;
            aspect = new Vector2(16, 9);
        }
        public Camera(Vector3 position, float pitch, float yaw, float fieldOfView, Vector2 aspect)
        {
            Position = position;
            Pitch = pitch;
            Yaw = yaw;
            FieldOfView = fieldOfView;
            Aspect = aspect;
        }
    }
}
