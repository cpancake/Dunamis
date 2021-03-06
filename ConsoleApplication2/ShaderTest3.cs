﻿using System.IO;
using Dunamis.Graphics;

namespace DunamisExamples
{
    public class ShaderTest3 : Shader
    {

        public override void Initialize()
        {
            AddParameter("Model", Model, false);
            AddParameter("View", View, false);
            AddParameter("Projection", Projection, false);
        }
        public override void Update()
        {
            UpdateParameter("Model", Model, false);
            UpdateParameter("View", View, false);
            UpdateParameter("Projection", Projection, false);
        }

        public ShaderTest3()
            : base(File.ReadAllText("Resources/newvert.txt"), File.ReadAllText("Resources/frag.txt"), ShaderState.Dynamic)
        {
        }
        public ShaderTest3(int yes)
            : base(File.ReadAllText("Resources/newvert.txt"), File.ReadAllText("Resources/fragf.txt"), ShaderState.Dynamic)
        {
        }
    }
}
