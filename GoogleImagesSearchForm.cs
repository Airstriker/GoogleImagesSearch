// Copyright (c) 2016 Julian Sychowski
// License: For non-commercial use only

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace GoogleImagesSearch
{
    /// <summary>
    /// A sample application to demonstrate the <see cref="TranslatorOld"/> class.
    /// </summary>
    public partial class GoogleImagesSearchForm : Form
    {
        #region Constructor

            /// <summary>
            /// Initializes a new instance of the <see cref="GoogleImagesSearchForm"/> class.
            /// </summary>
            public GoogleImagesSearchForm()
            {
                InitializeComponent();
            }

        #endregion

        #region Form event handlers

            /// <summary>
            /// Handles the Load event of the GoogleImagesSearchForm control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void GoogleImagesSearchForm_Load
                (object sender,
                 EventArgs e)
            {
            }

        #endregion

        #region Button handlers

            /// <summary>
            /// Handles the Click event of the _btnSearchImage control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void _btnSearchImage_Click(object sender, EventArgs e) {
                // Initialize the searcher
                GoogleImagesSearcher t = new GoogleImagesSearcher();

                // Translate the text
                try {
                    this.Cursor = Cursors.WaitCursor;
                    this._lblStatus.Text = "Searching...";
                    this._lblStatus.Update();
                    List<String> images_urls = t.SearchForImages (this._editImageText.Text.Trim());
                    if (t.Error == null && images_urls.Count > 0) {
                        //Show first image only
                        foreach (String image_url in images_urls) {
                            Bitmap bitmap = ImageUtil.LoadPicture(image_url);
                            if (bitmap != null) { //sometime the server refuses getting the image directly
                                Image image = ImageUtil.ResizeImage(bitmap, pictureBox1, true);
                                pictureBox1.Image = image;
                                if (bitmap != null) bitmap.Dispose();
                                break; //show only one image
                            }
                        }
                    }
                    else {
                        MessageBox.Show (t.Error.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    
                }
                catch (Exception ex) {
                    MessageBox.Show (ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally {
                    this._lblStatus.Text = string.Format ("Searched in {0} mSec", (int) t.SearchTime.TotalMilliseconds);
                    this.Cursor = Cursors.Default;
                }
            }

        #endregion

        #region Fields



        #endregion
    }
}
