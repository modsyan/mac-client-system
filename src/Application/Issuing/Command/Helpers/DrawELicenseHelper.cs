using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net;
using System.Net.Mime;
using QRCoder;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;

namespace MacClientSystem.Application.Issuing.Command.Helpers;

[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public static class DrawELicenseHelper
{
    public static void WriteOnCardImage(string imagePath, string outputImagePath, string name, string passportId,
        string bloodGroup, string permitClasses, string serialNumber, string gender, string birthDate,
        string issueDate, string expiryDate, string nationality, string residence, string accordingTo
    )

    {
        Image? originalImage = null;
        Bitmap? bitmap = null;
        Graphics? graphics = null;

        try
        {
            // Load the original image from the file path
            using FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            using (originalImage = Image.FromStream(fileStream))
            {
                // Create a new bitmap with the same dimensions as the original image
                using (bitmap = new Bitmap(originalImage.Width, originalImage.Height))
                {
                    // Create a graphics object to draw on the new bitmap
                    using (graphics = Graphics.FromImage(bitmap))
                    {
                        // Draw the original image on the new bitmap to retain image quality
                        graphics.DrawImage(originalImage, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

                        // Set the font and brush for the text
                        Font font = new Font("Arial", 20, FontStyle.Bold);
                        Brush brush = Brushes.Black; // You can choose any color you want

                        // Set the position for each text (adjust this according to your needs)
                        int x = 505;
                        int y = 155;
                        int yOffset = 41;

                        // Draw each text on the new bitmap at the specified positions
                        graphics.DrawString(name, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(birthDate, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(nationality, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(residence, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(passportId, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(gender, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(bloodGroup, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(accordingTo, font, brush, x, y);
                        y += yOffset;
                        graphics.DrawString(permitClasses, font, brush, x, y);
                        x = 202;
                        y = 90;
                        graphics.DrawString(issueDate, font, brush, x, y);
                        x = 835;
                        y = 576;
                        graphics.DrawString(expiryDate, font, brush, x, y);

                        Font font2 = new Font("Arial", 40, FontStyle.Bold);
                        x = 120;
                        y = 19;
                        graphics.DrawString(serialNumber, font2, brush, x, y);
                    }

                    // Save the modified bitmap to the output file path as PNG (lossless format)
                    bitmap.Save(outputImagePath, ImageFormat.Png);
                    // Dispose of the image and bitmap objects to release resources
                    originalImage.Dispose();
                    bitmap.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error while processing the image:", ex);
        }
        finally
        {
            // Dispose of the objects to release resources
            graphics?.Dispose();
            bitmap?.Dispose();
            originalImage?.Dispose();
        }
    }


    public static void QrCodeMaker(string imagePath, string outPath, string qrCodeData)
    {
        // Create the QR code generator
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeGenerated = qrGenerator.CreateQrCode(qrCodeData, QRCodeGenerator.ECCLevel.Q);

        // Create the QR code
        QRCode qrCode = new QRCode(qrCodeGenerated);
        Bitmap qrCodeImage = qrCode.GetGraphic(10, Color.Black, Color.Empty, false);

        // Load the base image
        Bitmap baseImage = new Bitmap(imagePath);

        // Set the position to draw the QR code on the base image (adjust these values as needed)
        // int x = baseImage.Width - qrCodeImage.Width + 140;
        // int y = baseImage.Height - qrCodeImage.Height - 40;

        int x = baseImage.Width - qrCodeImage.Width + 100;
        int y = baseImage.Height - qrCodeImage.Height - 80;

        // Draw the QR code on the base image
        using (Graphics graphics = Graphics.FromImage(baseImage))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.CompositingQuality = CompositingQuality.HighQuality;

            graphics.DrawImage(qrCodeImage, new Rectangle(x, y, 200, 200));
        }

        // Save the base image with the QR code as PNG
        baseImage.Save(outPath, ImageFormat.Png);

        // Dispose of the images
        qrCodeImage.Dispose();
        baseImage.Dispose();
    }

    public static void DrawPersonalImageFromLocal(string personalImagePath, string licenseImagePath, string outputImagePath)
    {
        // Load the background image
        Bitmap backgroundImage = new Bitmap(licenseImagePath); // Replace "background.jpg" with the path to your background image
    
        // Load the image to draw on top of the background
        Bitmap imageToDraw = new(personalImagePath); // Replace "overlay.png" with the path to your overlay image
        
        // Resize the imageToDraw to the desired size
        const int newWidth = 238; // Replace with the desired width
        const int newHeight = 290; // Replace with the desired height
        Bitmap resizedImage = ResizeImage(imageToDraw, newWidth, newHeight, 0);
        
        // Create a Graphics object from the background image
        using (Graphics graphics = Graphics.FromImage(backgroundImage))
        {
            // Set the interpolation mode to high quality to ensure smooth drawing
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
            // Draw the overlay image on top of the background image
            graphics.DrawImage(resizedImage,
                new Point(45, 188)); // You can adjust the coordinates (50, 50) as per your requirement
        }
    
        // Save the final image with lossless quality
        ImageCodecInfo?
            codec = GetEncoderInfo("image/png"); // Choose the appropriate codec based on your needs (PNG for lossless compression)
        EncoderParameters encoderParameters = new EncoderParameters(1);
        encoderParameters.Param[0] =
            new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L); // 100% quality for lossless compression
    
        backgroundImage.Save(outputImagePath, codec!, encoderParameters); // Replace "output.png" with the desired output file path
    
        // Dispose of the Bitmap objects to release resources
        backgroundImage.Dispose();
        resizedImage.Dispose();
        imageToDraw.Dispose();
    }
    
    

    public static async Task DrawPersonalImage(string personalImagePath, string licenseImagePath,
        string outputImagePath)
    {
        try
        {
            using (HttpClient httpClient = new HttpClient())
            using (HttpResponseMessage response = await httpClient.GetAsync(personalImagePath))
            await using (Stream stream = await response.Content.ReadAsStreamAsync())
            {
                using (Bitmap imageToDraw = new Bitmap(stream))
                {
                    // Load the background image
                    using (Bitmap backgroundImage = new Bitmap(licenseImagePath))
                    {
                        // Resize the imageToDraw to the desired size without rotation
                        const int newWidth = 238;
                        const int newHeight = 290;
                        using (Bitmap resizedImage =
                               ResizeImage(imageToDraw, newWidth, newHeight, 0)) // 0 degrees rotation
                        {
                            // Create a Graphics object from the background image
                            using (Graphics graphics = Graphics.FromImage(backgroundImage))
                            {
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.DrawImage(resizedImage, new Point(45, 188));
                            }
    
                            // Save the final image with lossless quality
                            ImageCodecInfo? codec = GetEncoderInfo("image/png");
                            EncoderParameters encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] =
                                new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
    
                            backgroundImage.Save(outputImagePath, codec!, encoderParameters);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static Bitmap ResizeImage(Image image, int newWidth, int newHeight, float rotationAngle)
    {
        Bitmap resizedImage = new Bitmap(newWidth, newHeight);

        using (Graphics graphics = Graphics.FromImage(resizedImage))
        {
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.TranslateTransform((float)newWidth / 2, (float)newHeight / 2);
            graphics.RotateTransform(rotationAngle);
            graphics.TranslateTransform(-(float)newWidth / 2, -(float)newHeight / 2);
            graphics.DrawImage(image, new Rectangle(0, 0, newWidth, newHeight));
        }

        return resizedImage;
    }
    
    
    private static ImageCodecInfo? GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        return encoders.FirstOrDefault(encoder => encoder.MimeType == mimeType);
    }
    
}
