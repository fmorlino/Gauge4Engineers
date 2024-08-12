using System.ComponentModel;
using System.Drawing.Drawing2D;
/*
MIT License

Copyright (c) 2024 Fabrizio Morlino

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Fabrizio Morlino
//     Website: https://www.linkedin.com/in/fabrizio-morlino-06b51128/
//     Created: 12/08/2024
//     Version: 1.0.0.0
// If you will use this control,
// leave me a greatings!
// and why not; let me know on Linkedin!
// |---------DO-NOT-REMOVE---------|

namespace Controls4Engineers
{
    public class Gauge4Engineers : Control
    {
        #region  [PROPERTIES]
        private const float PI = (float)Math.PI;

        /// <summary>
        /// Fires when Slider position has changed
        /// </summary>
        [Description("Event fires when the Value property changes")]
        [Category("Action")]
        public event EventHandler? ValueChanged = null;

        protected float _Value = 0f;
        /// <summary>
        /// Get or Set current gauge value
        /// </summary>
        [Description("Get or Set current gauge value")]
        [Category("Action")]
        public float Value
        {
            get => _Value;
            set
            {
                if (_Value > _Max)
                    _Value = _Max;
                else
                if (_Value < _Min)
                    _Value = _Min;
                else
                    _Value = value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                Refresh();
            }
        }

        protected float _Feedback = 0f;
        /// <summary>
        /// Get or Set current gauge value
        /// </summary>
        [Description("Get or Set the feedback value (little arrow inside)")]
        [Category("Action")]
        public float Feedback
        {
            get => _Feedback;
            set
            {
                _Feedback = value;
                Refresh();
            }
        }
        protected bool _ShowFeedback = false;
        /// <summary>
        /// If the little arrow of feedback has to be showen
        /// </summary>
        [Description("If the little arrow of feedback has to be showen")]
        [Category("Action")]
        public bool ShowFeedback
        {
            get => _ShowFeedback;
            set
            {
                _ShowFeedback = value;
                Refresh();
            }
        }

        float _Min = 0;
        float _Mid = 50;
        float _Max = 100;
        float _Ref = 0f;
        /// <summary>
        /// Minimum value
        /// </summary>
        [Description("Minimum value")]
        [Category("Action")]
        public float Min { get { return _Min; } set { _Min = value; Refresh(); } }
        /// <summary>
        /// Median value
        /// </summary>
        [Description("Median value")]
        [Category("Action")]
        public float Mid { get { return _Mid; } set { _Mid = value; Refresh(); } }
        /// <summary>
        /// Maximum value
        /// </summary>
        [Description("Maximum value")]
        [Category("Action")]
        public float Max { get { return _Max; } set { _Max = value; Refresh(); } }

        /// <summary>
        /// Reference value
        /// </summary>
        [Description("Reference value (little arrow outside)")]
        [Category("Action")]
        public float Reference { get { return _Ref; } set { _Ref = value; Refresh(); } }

        protected bool _ShowReference = false;
        /// <summary>
        /// If the little arrow of reference has to be showen
        /// </summary>
        [Description("If the little arrow of reference has to be showen")]
        [Category("Action")]
        public bool ShowReference
        {
            get => _ShowReference;
            set
            {
                _ShowReference = value;
                Refresh();
            }
        }

        float _Step = 1f;
        /// <summary>
        /// Single step value
        /// </summary>
        [Description("Single step value")]
        [Category("Action")]
        public float Step { get { return _Step; } set { _Step = value; } }
        float _StepMouse = 5f;
        /// <summary>
        /// Single step value
        /// </summary>
        //[Description("Single step value")]
        //[Category("Action")]
        //public float StepMouse { get { return _StepMouse; } set { _StepMouse = value; } }

        Pen? pen = null;
        int _StartAngle = 150; // fixed start angle
        int _SweepAngle = 240; // fixed end angle sweep
        float heightReductionFactor = 0.79f;
        bool mouseButtonPressed = false;
        Point dialerCenter = new Point();
        #endregion

        public Gauge4Engineers()
        {
            InitializeComponent();
            DoubleBuffered = true;
            //AutoScaleMode = AutoScaleMode.None;
            pen = new Pen(this.ForeColor);
            Size = new Size(183, 183);

            _ShowReference = true;
            _ShowFeedback = false;
            _Min = 0;
            _Mid = 50;
            _Max = 100;
            _Ref = 50;
            _Value = 0;
            _StartAngle = 150;
            _SweepAngle = 240;
            MinimumSize = new Size(64, (int)(64 * heightReductionFactor));

            MouseUp += new System.Windows.Forms.MouseEventHandler(Gauge4Engineers_MouseUp);
            MouseDown += new System.Windows.Forms.MouseEventHandler(Gauge4Engineers_MouseDown);
            MouseMove += new System.Windows.Forms.MouseEventHandler(Gauge4Engineers_MouseMove);
            MouseWheel += new System.Windows.Forms.MouseEventHandler(Gauge4Engineers_MouseWheel);
        }
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Gauge4Engineers
            // 
            Name = "Gauge4Engineers";
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ResumeLayout(false);
        }

        #region [MOUSE_EVENTES]
        private void Gauge4Engineers_MouseUp(object? sender, MouseEventArgs e)
        {
            mouseButtonPressed = false;
        }
        /*             -90
         *       -------|-------
         *       -   2  |   1  -
         *+/-180 -------|------- 0 grad
         *       -   3  |   4  -
         *       -------|-------
         *             +90
         */
        private void Gauge4Engineers_MouseDown(object? sender, MouseEventArgs e)
        {
            mouseButtonPressed = true;

            float angle = GetAngleOnCircle(dialerCenter, e.X, e.Y);
            float angle2 = (angle + 360) % 360;
            int quad = Quadrante(dialerCenter, e.X, e.Y);
            if (quad == 4)
                angle2 = 360 + angle2;
            if (angle2 < _StartAngle)
                angle2 = _StartAngle;
            else
            if (angle2 > _StartAngle + _SweepAngle)
                angle2 = _StartAngle + _SweepAngle;
            Value = (int)CalcY_2Point(angle2, _StartAngle, _Min, _StartAngle + _SweepAngle, _Max);
        }
        private void Gauge4Engineers_MouseMove(object? sender, MouseEventArgs e)
        {
            // Ottieni la posizione del mouse sullo schermo
            Point mousePosition = Cursor.Position;
            // Converti la posizione del mouse in coordinate relative al form
            Point relativePosition = this.PointToClient(mousePosition);

            if (mouseButtonPressed)
            {
                float angle = GetAngleOnCircle(dialerCenter, relativePosition.X, relativePosition.Y);
                float angle2 = (angle + 360) % 360;
                int quad = Quadrante(dialerCenter, relativePosition.X, relativePosition.Y);
                if (quad == 0)
                    return;
                else
                if (quad == 4)
                    angle2 = 360 + angle2;
                if (angle2 < _StartAngle)
                    angle2 = _StartAngle;
                else
                if (angle2 > _StartAngle + _SweepAngle)
                    angle2 = _StartAngle + _SweepAngle;
                Value = (int)CalcY_2Point(angle2, _StartAngle, _Min, _StartAngle + _SweepAngle, _Max);
            }
        }
        protected void Gauge4Engineers_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
                _Value -= _Step;
            else
                _Value += _Step;
            Value = _Value;
        }
        #endregion

        #region [CALC_UTILITY]
        /// <summary>
        /// Linear interpolation
        /// </summary>
        /// <param name="x">set a quote X</param>
        /// <param name="x1">we knows (x1,y1)</param>
        /// <param name="y1">we knows (x1,y1)</param>
        /// <param name="x2">we knows (x2,y2)</param>
        /// <param name="y2">we knows (x2,y2)</param>
        /// <returns>calculate Y value</returns>
        static float CalcY_2Point(float x, float x1, float y1, float x2, float y2)
        {
            float A, B, C, D;
            A = y2 - y1;
            B = x - x1;
            C = x2 - x1;
            if (C == 0)
                C = 1f;
            return D = ((A * B) / C) + y1;
        }
        /// <summary>
        /// Polar coordinates
        /// </summary>
        /// <param name="centre">Centre point</param>
        /// <param name="angleRadian">Angle in radians</param>
        /// <param name="diameter">a diameter</param>
        /// <returns>A new point with set angle and distance</returns>
        static Point GetPointOnCircle(Point centre, float angleRadian, float diameter)
        {
            return new Point(
                (int)(Math.Cos(angleRadian) * diameter) + centre.X,
                (int)(Math.Sin(angleRadian) * diameter) + centre.Y);
        }
        /// <summary>
        /// In wich quadrant we are?
        /// </summary>
        /// <param name="centre"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns>1,2,3,4 or 0</returns>
        /*             -90
         *       -------|-------
         *       -   2  |   1  -
         *+/-180 -------|------- 0 grad
         *       -   3  |   4  -
         *       -------|-------
         *             +90
         */
        int Quadrante(Point centre, int X, int Y)
        {
            if (X > centre.X && Y < centre.Y)
                return 1;
            else if (X < centre.X && Y < centre.Y)
                return 2;
            else if (X < centre.X && Y > centre.Y)
                return 3;
            else if (X > centre.X && Y > centre.Y)
                return 4;
            else
                return 0;
        }
        static float GetAngleOnCircle(Point centre, int X, int Y)
        {
            // Calcola il vettore dal centro al punto
            double v_x = X - centre.X;
            double v_y = Y - centre.Y;
            // Calcola il diametro (distanza dal centro al punto)
            //double diameter = Math.Sqrt(v_x * v_x + v_y * v_y);
            // Calcola l'angolo in radianti
            double angleRadians = Math.Atan2(v_y, v_x);
            // Converti l'angolo in gradi
            return (float)(angleRadians * (180.0 / Math.PI));
        }
        static float DegreeToRadian(float angle)
        {
            return (PI * angle) / 180f;
        }
        static float RadianToDegree(float angle)
        {
            return angle * (180f / PI);
        }
        #endregion

        #region [WINFORM_EVENTS]
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int fattoreScala = (int)(Width * 0.11f);
            if (fattoreScala < 5)
                fattoreScala = 5;

            float valueAngle = 0;

            // ARC
            if (pen == null)
                pen = new Pen(ForeColor);
            pen.Color = ForeColor;
            pen.Width = fattoreScala;
            pen.StartCap = LineCap.Flat;
            pen.EndCap = LineCap.Flat;
            // Facciamo i conti su un quadrato H=W
            Rectangle rectArco = new Rectangle(
                ClientRectangle.X, ClientRectangle.Y,
                ClientRectangle.Width, ClientRectangle.Width);
            dialerCenter = new Point(rectArco.Width / 2, rectArco.Height / 2);

            rectArco.Inflate(-(fattoreScala + 8), -(fattoreScala + 8));
            g.DrawArc(pen, rectArco, _StartAngle, _SweepAngle);

            // Gauge
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Triangle;
            pen.Width = (int)(fattoreScala * 0.75);
            valueAngle = CalcY_2Point(_Value, _Min, _StartAngle, _Max, _StartAngle + _SweepAngle);
            Point valuePoint = GetPointOnCircle(dialerCenter,
                DegreeToRadian(valueAngle),
                (rectArco.Width / 2) - (int)(fattoreScala));
            g.DrawLine(pen, dialerCenter, valuePoint);

            pen.Width = fattoreScala / 2;

            // Reference
            if (ShowReference)
            {
                pen.Width = 1;
                valueAngle = CalcY_2Point(_Ref, _Min, _StartAngle, _Max, _StartAngle + _SweepAngle);
                int distanzaPiuVicina = (int)((rectArco.Width / 2) + fattoreScala * 0.5) + 1;
                int distanzaPiuLontana = (int)(distanzaPiuVicina + fattoreScala * 0.7) + 1;
                Point A = GetPointOnCircle(dialerCenter, DegreeToRadian(valueAngle), distanzaPiuVicina);
                Point B = GetPointOnCircle(dialerCenter, DegreeToRadian(valueAngle - 5), distanzaPiuLontana);
                Point C = GetPointOnCircle(dialerCenter, DegreeToRadian(valueAngle + 5), distanzaPiuLontana);
                Point[] vertici = new Point[] { A, B, C };
                g.FillPolygon(new SolidBrush(ForeColor), vertici);
            }

            // Feedback
            if (ShowFeedback)
            {
                pen.Width = 1;
                valueAngle = CalcY_2Point(_Feedback, _Min, _StartAngle, _Max, _StartAngle + _SweepAngle);
                int distanzaPiuLontana = (int)((rectArco.Width / 2) - fattoreScala * 0.5);
                int distanzaPiuVicina = (int)(distanzaPiuLontana - fattoreScala * 0.7);
                Point A = GetPointOnCircle(dialerCenter, DegreeToRadian(valueAngle), distanzaPiuLontana);
                Point B = GetPointOnCircle(dialerCenter, DegreeToRadian(valueAngle - 15), distanzaPiuVicina);
                Point C = GetPointOnCircle(dialerCenter, DegreeToRadian(valueAngle + 15), distanzaPiuVicina);
                Point[] vertici = new Point[] { A, B, C };
                g.FillPolygon(new SolidBrush(ForeColor), vertici);
            }
            //pen.Width = 2;
            //g.DrawRectangle(pen, rectArco);

            // Value as Text
            string _Text = _Value.ToString();
            SizeF size = g.MeasureString(_Text, this.Font);
            Point _TextLocation = new Point(
              rectArco.Location.X + ((rectArco.Width / 2) - (int)(size.Width / 2)),
              Height - (int)size.Height);
            g.DrawString(_Text, this.Font, new SolidBrush(ForeColor), _TextLocation);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Width < MinimumSize.Width)
                Width = MinimumSize.Width;
            Height = (int)(Width * heightReductionFactor);
            Refresh();
        }
        #endregion
    }

}
