﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Platform.Graphics;


namespace Platform.World
{
    class Particle:Entity
    {

        private float maxLife;
        private float lifeTime;
        private float degen;
        private Vector3 colorSpeed;
        private Vector2 maxSize;
        private float acceleration;

        public float Acceleration
        {
            get { return acceleration; }
            set { acceleration = value; }
        }

        public Vector3 ColorSpeed
        {
            get { return colorSpeed; }
            set { colorSpeed = value; }
        }
        public Vector2 MaxSize
        {
            get { return maxSize; }
            set { maxSize = value; }
        }
        public float MaxLifeTime
        {
            get { return maxLife; }
            set { maxLife = value; }
        }
        public float LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }
        public float Degeneration
        {
            get { return degen; }
            set { degen = value; }
        }

        public override Map Parent
        {
            get { return parent; }
            set
            {
                if (parent != null)
                {
                    parent.RemoveParticle(this);
                }
                if (value != null)
                {
                    value.AddParticle(this);
                }
                parent = value;
            }
        }

        public Particle():base()
        {
            maxLife = 5;
            lifeTime = maxLife;
            maxSize = new Vector2(2);
            size = maxSize;
            texture = Game1.particleSheets["DefaultParticle"];
            SourceRect = texture.Bounds;
            color = Color.Red;
            colorSpeed = new Vector3();
            acceleration = -50;
        }

        public Particle(float life, float siz):base()
        {
            maxLife = life;
            lifeTime = maxLife;
            maxSize = new Vector2(siz);
            size = maxSize;
            texture = Game1.particleSheets["DefaultParticle"];
            SourceRect = Texture.Bounds;
            color = Color.Red;
            colorSpeed = new Vector3();
            acceleration = -50;
        }

        public override void Update(float timeElapsed)
        {
            Position += Velocity * timeElapsed;
            Velocity = new Vector2(Velocity.X, Velocity.Y + timeElapsed * parent.Gravity *(float).5);
            lifeTime -= timeElapsed;
            size = maxSize*(lifeTime/maxLife);
            float toDec = velocity.Length();
            Vector2 dir = velocity;
            dir.Normalize();
            velocity = velocity + dir * acceleration * timeElapsed;
            color = new Color((byte)(color.R + colorSpeed.X * timeElapsed), (byte)(color.G + colorSpeed.Y * timeElapsed), (byte)(color.B + colorSpeed.Z * timeElapsed));
            if (lifeTime <= 0)
            {
                Parent = null;
            }

        }

    }
}
