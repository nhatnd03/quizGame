using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizGame.Resources.Custom
{
    public class TransparentLabel:Label
    {
        public TransparentLabel() 
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
           // Set the background to transparent
            base.OnPaint(e);  // Draw the label as usual
        }
    }
}
