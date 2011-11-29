using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CityDefender
{
    class Shield : GameObject
    {
        protected static bool shield;

        public Shield(GamePanel _MyPanel)
        { 
            
        }

        public double ShieldRadius
        {
            get { return shieldRadius; }
            set { shieldRadius = value; }
        }
        public bool ShieldActive
        {
            get { return shield; }
            set { shield = value; }
        }

        private Size panelSize()
        {
            return _MyPanel.ClientRectangle.Size;
        }

        public static void disableShield()
        {
            shield = false;
        }

        public override void draw(Graphics g)
        {
            //g.DrawEllipse(Pens.Black, 100f, 100f, 100f, 100f);
            g.DrawEllipse(Pens.Black, 0f, 600f * 2f / 3f, 600f, 600f);
        }
    }
}
