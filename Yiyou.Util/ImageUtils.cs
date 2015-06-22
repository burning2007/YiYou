using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Yiyou.Util
{
    public class ImageUtils
    {
        const int THUMBNAIL_MIN_SIDE = 100;
        private static Page _Page = new Page();


        #region image thumbnail functions

        public static byte[] getThumbnail(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes);

            byte[] ret = getThumbnail(ms);

            ms.Close();
            ms.Dispose();

            return ret;
        }

        public static byte[] getThumbnail(MemoryStream memoryStream)
        {
            byte[] buffer = null;

            try
            {
                Image img = Image.FromStream(memoryStream);

                if (Math.Min(img.Width, img.Height) > THUMBNAIL_MIN_SIDE)
                {
                    int w, h;
                    if (img.Width < img.Height)
                    {
                        w = THUMBNAIL_MIN_SIDE;
                        h = img.Height * THUMBNAIL_MIN_SIDE / img.Width;
                    }
                    else
                    {
                        w = img.Width * THUMBNAIL_MIN_SIDE / img.Height;
                        h = THUMBNAIL_MIN_SIDE;
                    }

                    Image thumb = img.GetThumbnailImage(w, h, null, IntPtr.Zero);

                    buffer = imageToByteArray(thumb);

                    thumb.Dispose();
                }
                else
                {
                    buffer = memoryStream.ToArray();
                }
                img.Dispose();
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.Write(ex);
            }

            return buffer;
        }

        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        #endregion

        /// <summary>
        /// Get the temp folder path
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string GetTempFolderPath()
        {
            try
            {
                return HttpContext.Current.Server.MapPath("~/Temp/");
            }
            catch { }
            try
            {
                string strTempPath = System.AppDomain.CurrentDomain.BaseDirectory;
                return Path.Combine(strTempPath, "Temp");
            }
            catch { }
            return string.Empty;
        }

        /// <summary>
        /// Show Thumbnail
        /// </summary>
        /// <param name="litImagePreview"></param>
        /// <param name="strFileName">Only File Name, not path</param>
        public static void ShowThumbnail(System.Web.UI.WebControls.Literal litImagePreview, string strFileName)
        {
            litImagePreview.Text = string.Format("<img style=\"width: 100%; padding: 4px;\" class=\"bg-white border\"  src=\"/temp/{0}\" />", strFileName);
        }

        /// <summary>
        /// Upload a image file, show thumbnail and return the saved path
        /// </summary>
        /// <param name="ctrlFileUpload"></param>
        /// <returns></returns>
        public static string uploadImageFile(
            System.Web.UI.WebControls.FileUpload ctrlFileUpload,  // FileUpload Control
            System.Web.UI.WebControls.Literal litImagePreview,    // Show the upload image           
            System.Web.UI.Page page)
        {
            bool fileOK = false;
            String fileExtension = string.Empty;
            string uploadTempFolder = GetTempFolderPath();
            if (ctrlFileUpload.HasFile)
            {
                fileExtension = System.IO.Path.GetExtension(ctrlFileUpload.FileName).ToLower();
                String[] allowedExtensions = { ".jpg", ".png", ".bmp", ".jpeg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                        break;
                    }
                }
            }

            // Check file type
            if (!fileOK)
            {
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('仅支持上传图片格式的文件！');");
                page.ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                return "";
            }

            // Check length, can't exceed 4M
            if (ctrlFileUpload.FileBytes.Length > 4 * 1024 * 1024)
            {
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('文件大小超过限制，请编辑后重试！');");
                page.ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                return "";
            }

            try
            {
                string strFileName = Guid.NewGuid().ToString() + fileExtension;
                string strFilePath = uploadTempFolder + strFileName;
                ctrlFileUpload.SaveAs(strFilePath);
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('文件上传成功');");
                page.ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                //litImagePreview.Text = string.Format("<img width=\"100\" height=\"100\" src=\"/temp/{0}\" />", strFileName);
                ShowThumbnail(litImagePreview, strFileName);
                return strFilePath;
            }
            catch
            {
                string strScript = string.Format("window.setTimeout(\"{0}\", 100);", "alert('文件上传失败！请重试！');");
                page.ClientScript.RegisterClientScriptBlock(typeof(string), "uploadPurposeImage", strScript, true);
                return "";
            }
        }
    }
}
