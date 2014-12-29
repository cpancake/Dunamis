﻿using System;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Dunamis.Graphics
{
    public class Renderer // TODO: implement safe mode for performance
    {
        GraphicsContext graphicsContext;

        #region Properties
        public Color3 ClearColor
        {
            get
            {
                return new Color3();
            }
            set
            {
                GL.ClearColor(new Color4(value.R, value.G, value.B, 255));
            }
        }
        #endregion

        public void Clear()
        {
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
        }
        public void Display()
        {
            graphicsContext.SwapBuffers();
        }

        public void Draw(Mesh mesh)
        {
            GL.BindVertexArray(mesh.VertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, mesh.VertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, mesh.IndexBufferObject);
            GL.UseProgram(mesh.Shader.ShaderProgram);

            GL.DrawElements(PrimitiveType.Triangles, mesh.Indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
        }

        public Renderer(Window window)
        {
            graphicsContext = new GraphicsContext(GraphicsMode.Default, window.NativeWindow.WindowInfo);
            graphicsContext.LoadAll();
        }
    }
}
