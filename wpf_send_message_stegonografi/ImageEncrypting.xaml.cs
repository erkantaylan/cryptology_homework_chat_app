using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Lib3DES;

using Microsoft.Win32;

using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace wpf_send_message_stegonografi {

    public partial class UserControl1 {

        private const string Key = "MCym6O8sN8UZug2GgLSE8aK8";

        public UserControl1() {
            InitializeComponent();
        }

        private void btnChooseImage_OnClick(object sender, RoutedEventArgs e) {
            var ofd = new OpenFileDialog {
                Filter = "PNG Files (*.png)|*.png"
            };
            var result = ofd.ShowDialog();
            if ( result == false )
                return;
            var imgSource = new BitmapImage(new Uri(ofd.FileName));
            this.image.Source = imgSource;

            this.image.Stretch = Stretch.None;
        }

        private void btnEncryp_OnClick(object sender, RoutedEventArgs e) {
            var imgS = this.image.Source;

            var bitmap = BitmapSourceToBitmap(imgS as BitmapSource);
            var imageAsString = ImageToBase64(bitmap, ImageFormat.Png);

            var cyperText = ThreeDesEngine.Encrypt(imageAsString, Key);
            this.txtCyper.Text = cyperText;
        }


        private static string ImageToBase64(Bitmap image, ImageFormat format) {
            using ( var ms = new MemoryStream() ) {
                // Convert Image to byte[]
                image.Save(ms, format);
                var imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                var base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        private static Image Base64ToImage(string base64String) {
            // Convert Base64 String to byte[]
            var imageBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(
                imageBytes,
                0,
                imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            var image = Image.FromStream(ms, true);
            return image;
        }

        private static Bitmap BitmapSourceToBitmap(BitmapSource srs) {
            var width = srs.PixelWidth;
            var height = srs.PixelHeight;
            var stride = width * ( ( srs.Format.BitsPerPixel + 7 ) / 8 );
            var ptr = IntPtr.Zero;
            try {
                ptr = Marshal.AllocHGlobal(height * stride);
                srs.CopyPixels(new Int32Rect(0, 0, width, height), ptr, height * stride, stride);
                using ( var btm = new Bitmap(width, height, stride, PixelFormat.Format1bppIndexed, ptr) ) {
                    // Clone the bitmap so that we can dispose it and
                    // release the unmanaged memory at ptr
                    return new Bitmap(btm);
                }
            } finally {
                if ( ptr != IntPtr.Zero )
                    Marshal.FreeHGlobal(ptr);
            }
        }

        private void btnDecrpyt_OnClick(object sender, RoutedEventArgs e) {
            var cyper = ThreeDesEngine.Decrypt(this.txtCyper.Text, Key);
            var path = @"C:/ldrk5yjdlkrtjyldktrjylkdjty.png";
            
            Base64ToImage(cyper).Save(path);
            this.imgDecrpyted.Source = new BitmapImage(new Uri(path));
        }

    }

}