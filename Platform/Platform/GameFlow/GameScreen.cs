﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platform.GameFlow
{
    abstract class GameScreen
    {

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

    }
}