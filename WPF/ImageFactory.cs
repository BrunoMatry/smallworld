using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF {
	class ImageFactory {
		private ImageBrush desert, eau, foret, montagne, plaine;

		public ImageFactory() {
		
			BitmapImage _imageDesert = new BitmapImage(new Uri(@"../textures/terrains/desert.png", UriKind.Relative));
			BitmapImage _imageEau = new BitmapImage(new Uri(@"../textures/terrains/eau.png", UriKind.Relative));
			BitmapImage _imageForet = new BitmapImage(new Uri(@"../textures/terrains/foret.png", UriKind.Relative));
			BitmapImage _imageMontagne = new BitmapImage(new Uri(@"../textures/terrains/montagne.png", UriKind.Relative));
			BitmapImage _imagePlaine = new BitmapImage(new Uri(@"../textures/terrains/plaine.png", UriKind.Relative));

			desert = new ImageBrush();
			eau = new ImageBrush();
			foret = new ImageBrush();
			montagne = new ImageBrush();
			plaine = new ImageBrush();

			desert.ImageSource = _imageDesert;
			eau.ImageSource = _imageEau;
			foret.ImageSource = _imageForet;
			montagne.ImageSource = _imageMontagne;
			plaine.ImageSource = _imagePlaine;
		}

		public ImageBrush getImageBrush(TypeCase t)	{
			ImageBrush image = null;
			switch (t) {
				case TypeCase.DESERT:
					image = desert;
					break;
				case TypeCase.EAU:
					image = eau;
					break;
				case TypeCase.FORET:
					image = foret;
					break;
				case TypeCase.MONTAGNE:
					image = montagne;
					break;
				case TypeCase.PLAINE:
					image = plaine;
					break;
				default:
					break;
			}
			return image;
		}
	}
}