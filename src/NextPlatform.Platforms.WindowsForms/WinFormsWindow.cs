// Licensed under the MIT license.
// See the LICENSE file in the project root for more information.

using NextPlatform.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NextPlatform.Rendering;
using NextPlatform.Metrics;
using NextPlatform.Core;

namespace NextPlatform.Platforms.WindowsForms
{
    public class WinFormsWindow : PlatformWindow
    {
        internal readonly Form form;
        readonly IApplication app;
        
        public WinFormsWindow(IApplication app)
        {
            this.app = app;
            form = new Form() { Width = 1280, Height = 900 };
            form.Resize += Form_Resize;
            form.Paint += formPaint;
            form.KeyPress += Form_KeyPress;
        }

        private void Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            DUMMY.LASTKEY = e.KeyChar;
            ((Form)sender).Invalidate(false);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            ((Form)sender).Invalidate(false);
        }

        private void formPaint(object sender, PaintEventArgs e)
        {
            var bitmap = new Bitmap(form.Width, form.Height, PixelFormat.Format32bppPArgb);
            var data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, form.Width, form.Height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            var buffer = new FrameBitmapBuffer()
            {
                Width = form.Width,
                Height = form.Height,
                RowBytes = data.Stride,
                Pixels = data.Scan0
            };

            app.RenderEngine.RenderFrame(buffer, this);

            bitmap.UnlockBits(data);
            e.Graphics.DrawImage(bitmap, 0, 0);
        }


        public override void Dispose()
        {
            form.Dispose();
        }

        public override void Show()
        {
            form.Show();
        }

        public override Metrics.Size ClientSize => new Metrics.Size(new Length2(form.ClientSize.Width, UnitType.Pixel), new Length2(form.ClientSize.Height, UnitType.Pixel));
    }
}
