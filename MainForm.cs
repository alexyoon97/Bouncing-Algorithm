using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ica2
{
    public partial class Form1 : Form
    {
        CDrawer canvas;
        List<Ball> BallList = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            _Timer.Enabled = true;
            canvas = new CDrawer();
            canvas.ContinuousUpdate = false;

            _Timer.Tick += _Timer_Tick;
            _tbOpa.Scroll += _tbOpa_Scroll;
            _tbX.Scroll += _tbX_Scroll;
            _tbY.Scroll += _tbY_Scroll;
        }

        private void _tbY_Scroll(object sender, EventArgs e)
        {
            if (_cbAll.Checked)
                for (int i = 0; i < BallList.Count; i++)
                    BallList[i].vely = _tbY.Value;
            else
                BallList.Last().vely = _tbY.Value;
            _lbY.Text = "Y :"+_tbY.Value.ToString();
        }

        private void _tbX_Scroll(object sender, EventArgs e)
        {
            if (_cbAll.Checked)
                BallList.ForEach(x => x.velx = _tbX.Value);
            else
                BallList.Last().velx = _tbX.Value;
            _lbX.Text = "X :"+_tbX.Value.ToString();

        }

        private void _tbOpa_Scroll(object sender, EventArgs e)
        {
            if (_cbAll.Checked)
                for (int i = 0; i < BallList.Count; i++)
                    BallList[i].BallOpa = _tbOpa.Value;
            else
                BallList.Last().BallOpa = _tbOpa.Value;
            lbOpa.Text = "Opacity :" + _tbOpa.Value.ToString();

        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            Point p;
            if(canvas.GetLastMouseLeftClick(out p))
            {
                BallList.Add(new Ball(p));
            }
            else if(canvas.GetLastMouseRightClick(out p))
            {
                BallList.Clear();
            }
            canvas.Clear();
            for (int i = 0; i < BallList.Count; i++)
            {
                BallList[i].MoveBall(canvas);
                BallList[i].ShowBall(canvas);
                this.Text = BallList[i].ToString();

            }
            canvas.Render();
        }
    }
}
