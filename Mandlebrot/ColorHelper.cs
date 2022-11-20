using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandlebrotView
{
    internal class ColorHelper
    {
		internal struct RGB
		{
			private byte _r;
			private byte _g;
			private byte _b;

			internal RGB(byte r, byte g, byte b)
			{
				this._r = r;
				this._g = g;
				this._b = b;
			}

			internal byte R
			{
				get { return this._r; }
				set { this._r = value; }
			}

			internal byte G
			{
				get { return this._g; }
				set { this._g = value; }
			}

			internal byte B
			{
				get { return this._b; }
				set { this._b = value; }
			}

			internal bool Equals(RGB rgb)
			{
				return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
			}
		}

		internal struct HSL
		{
			private int _h;
			private float _s;
			private float _l;

			internal HSL(int h, float s, float l)
			{
				this._h = h;
				this._s = s;
				this._l = l;
			}

			internal int H
			{
				get { return this._h; }
				set { this._h = value; }
			}

			internal float S
			{
				get { return this._s; }
				set { this._s = value; }
			}

			internal float L
			{
				get { return this._l; }
				set { this._l = value; }
			}

			internal bool Equals(HSL hsl)
			{
				return (this.H == hsl.H) && (this.S == hsl.S) && (this.L == hsl.L);
			}
		}

		internal static RGB HSLToRGB(HSL hsl)
		{
			byte r = 0;
			byte g = 0;
			byte b = 0;

			if (hsl.S == 0)
			{
				r = g = b = (byte)(hsl.L * 255);
			}
			else
			{
				float v1, v2;
				float hue = (float)hsl.H / 360;

				v2 = (hsl.L < 0.5) ? (hsl.L * (1 + hsl.S)) : ((hsl.L + hsl.S) - (hsl.L * hsl.S));
				v1 = 2 * hsl.L - v2;

				r = (byte)(255 * HueToRGB(v1, v2, hue + (1.0f / 3)));
				g = (byte)(255 * HueToRGB(v1, v2, hue));
				b = (byte)(255 * HueToRGB(v1, v2, hue - (1.0f / 3)));
			}

			return new RGB(r, g, b);
		}

		private static float HueToRGB(float v1, float v2, float vH)
		{
			if (vH < 0)
				vH += 1;

			if (vH > 1)
				vH -= 1;

			if ((6 * vH) < 1)
				return (v1 + (v2 - v1) * 6 * vH);

			if ((2 * vH) < 1)
				return v2;

			if ((3 * vH) < 2)
				return (v1 + (v2 - v1) * ((2.0f / 3) - vH) * 6);

			return v1;
		}
	}
}
