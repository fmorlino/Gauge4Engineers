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
using System.Diagnostics;

namespace Controls4Engineers_WinformTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _stopwatch = Stopwatch.StartNew();
        }
        long tx, last;
        float Y, Yi;
        bool init = false;
        Stopwatch _stopwatch;
        public float FILTER_I(float x, int T_ms)
        {
            // read system time
            tx = _stopwatch.ElapsedMilliseconds;
            // startup initialisation
            if (!init)
            {
                init = true;
                Yi = x * 1000;
            }
            else
            {
                // to increase accuracy of the filter we calculate internal Yi wich is Y*1000
                Yi = Yi + (x - Y) * (tx - last) * 1000 / T_ms;
            }
            last = tx;
            Y = Yi / 1000;
            return Y;
        }

        private void gauge4Engineers2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gauge4Engineers2.Feedback = FILTER_I(gauge4Engineers2.Value, 800);
        }
    }
}
